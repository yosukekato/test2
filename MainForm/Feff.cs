using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BTWrapper
{
    public partial class BTMainForm : Form
    {
        //smooth.inpの生成
        private string CreateSmoothInp(bool exp)
        {
            string res;
            SmoothCreateWindow smw = new SmoothCreateWindow(exp);
            AddOwnedForm(smw);

            if (smw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                res = smw.Filename;
            else
                res = "";
            RemoveOwnedForm(smw);
            return res;
        }
        //指定プログラムを走らせる
        private void RunProgram(string program)
        {
            try
            {
                Process Feff = new Process();
                log.AddL("CurrentDirectory:" + Directory.GetCurrentDirectory());
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.FileName = program;

                Feff.StartInfo = startInfo;
                Feff.Start();
                // リダイレクトがあったときに呼ばれるイベントハンドラ
                Feff.OutputDataReceived +=
                new DataReceivedEventHandler((obj, args) =>
                {
                    // UI操作のため、表スレッドにて実行
                    this.BeginInvoke(new Action<String>(str =>
                    {
                        if (!this.Disposing && !this.IsDisposed)
                        {
                            log.AddL(str);
                        }
                    }), new object[] { args.Data });

                });

                // 非同期ストリーム読み取りの開始
                Feff.BeginOutputReadLine();
                while (!Feff.HasExited)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
                Feff.CancelOutputRead();
                Feff.Close();
            }
            catch
            {
                //log.AddL("Error!:exception ocuured in running program");
            }
        }
        //オープンファイルダイアログ→ファイル名取得までを一括
        private string GetOpenFileDialogName(string deffilename, string filter, string title)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (deffilename != "")
                ofd.FileName = deffilename;
            ofd.Filter = filter;
            ofd.Title = title;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return ofd.FileName;
            else
                return "";
        }
        //ファイル名が同じかどうかの判定
        private bool IsSameFileName(string f1, string f2)
        {
            if (string.IsNullOrEmpty(f1) || string.IsNullOrEmpty(f2))
                return false;
            return Path.GetFullPath(f1) == Path.GetFullPath(f2);
        }
        //ファイルを移動。同じファイルがあったら上書き
        private void MoveFile_overwrite(string source, string dest)
        {
            if (!File.Exists(source))
            {
                log.AddL(source + " is not exist");
                return;
            }
            if (File.Exists(dest))
            {
                File.Delete(dest);
            }
            File.Move(source, dest);
        }
        //Logウインドウの生成と管理
        private void CreateLogWindow(bool clear = false)
        {
            foreach (Form f in this.OwnedForms)
            {
                if (f.Name == "LogWindow")
                {
                    if (clear == true)
                    {
                        ((LogWindow)f).Flush();
                    }
                    return;
                }
            }

            log = new LogWindow(new Point(this.Location.X + this.Size.Width, this.Location.Y));
            log.Name = "LogWindow";
            this.AddOwnedForm(log);
            log.Show();
        }

        //K端Feffの全工程(feff + chimod + smooth)
        private void RunFeffKEdge()
        {
            try
            {
                string Current = PrepareEachProcess("running...");
                log.AddL("1. run feff&chimod&smooth");
                RunFeffK_Only(true);
                log.AddL("2. feff program success");
                RunChimodTxtK(true);
                log.AddL("3. chimod program success");
                RunSmooth(true);
                log.AddL("4. smooth program sucess");
                Directory.SetCurrentDirectory(Current);

                bt_runfeff.Text = "Run feff preparation";

                System.GC.Collect();
                EndEachProcess("----------- all process finished ------------",Current);
            }
            catch
            {
                EndEachProcess("Error!!", Directory.GetCurrentDirectory() );
            }
        }
        //内部用feff.inpの変更
        private void ReplaceCONTROL_and_CRITERIA(double criteria)
        {
            using (StreamWriter sw = new StreamWriter("feff.inp", false, BTMainForm.CharEncode))
            {
                foreach (string line in File.ReadLines("feff.inp.original",BTMainForm.CharEncode))
                {
                    if (line.Contains("CRITERIA") )
                        sw.Write("CRITERIA " + (criteria * 2) + " " + criteria + "\n");
                    else if (line.Contains("CONTROL") )
                        sw.Write("CONTROL   0      0     0     0     1      1\n");
                    else
                        sw.Write(line + "\n");
                }
            }
        }
        //feffのみ
        private void RunFeffK_Only(bool throw_exception = false)
        {
            log.AddL("Create Folders");
            try
            {
                // K , Kd　, feffdat , chidat , xmudat フォルダの生成
                foreach (string s in new string[] { "K", "Kd", "feffdat", "chidat", "xmudat" })
                {
                    if (!Directory.Exists(s))
                        Directory.CreateDirectory(s);
                }
                //feff.inpをコピー
                if (File.Exists(txt_feffinp.Text) && IsSameFileName(txt_feffinp.Text, "feff.inp") == false)
                    File.Copy(txt_feffinp.Text, "feff.inp", true);
                if (!File.Exists(txt_feffinp.Text))
                {
                    log.AddL("Error!:feff.inp is not exist");
                    bt_runfeff.Enabled = true;
                    bt_runfeff.Text = "run feff preparation";
                    return;
                }

                RunFeffK_Normal();
                RunFeffK_Deformed();
                RunFeffK_ChangeCriteria(1.5, 0.3, 0.03);

                File.Copy("feff.inp.original", "feff.inp", true);
                Directory.SetCurrentDirectory("../");
                log.AddL("_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/");
                log.AddL("feff process finished");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                log.SaveException();
                bt_runfeff.Text = "Run feff preparation";
                if (throw_exception)
                    throw new Exception(e.Message);
            }
        }
        private void RunFeffK_Normal()
        {
            //-------------------------------通常のFeff-------------------------
            File.Copy("feff.inp", "K/feff.inp", true);
            Directory.SetCurrentDirectory("K");
            log.AddL("normal feff run  for K");
            RunProgram(ExeFileDirectory + "/feff83_mod");
            log.AddL("---------- feff finished -----------");

            foreach (string s in Directory.GetFiles(Directory.GetCurrentDirectory(), "feff*.dat"))
            {
                string s1 = Path.GetFileName(s);
                string s2 = "../feffdat/" + Path.GetFileName(s.Replace("feff", "ff01"));
                MoveFile_overwrite(s1, s2);
            }
            MoveFile_overwrite("chi.dat", "../chidat/chi_K.dat");
            MoveFile_overwrite("xmu.dat", "../xmudat/xmu_K.dat");
            File.Copy("feff.inp", "../feffdat/feff1.inp", true);
            File.Copy("paths.dat", "../feffdat/paths1.dat", true);
            File.Copy("paths.dat", "../chidat/path00_K.dat", true);
            Directory.SetCurrentDirectory("../");
            GC.Collect();
        }
        private void RunFeffK_Deformed()
        {
            //-------------------------------少し格子変形させたFeff-------------------------
            log.AddL("deformed FEFF run for K");

            using (StreamReader sr = new StreamReader("feff.inp", BTMainForm.CharEncode))
            {
                using (StreamWriter sw = new StreamWriter("Kd/feff.inp", false, BTMainForm.CharEncode))
                {
                    string s;
                    sw.Write("RMULTIPLIER 0.99\n");
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        if (s.IndexOf("CRITERIA") >= 0)
                            sw.Write("CRITERIA 0.0 0.0\n");
                        else
                            sw.Write(s + "\n");
                    }
                }
            }

            Directory.SetCurrentDirectory("Kd");
            RunProgram(ExeFileDirectory + "/feff83_mod");
            log.AddL("---------- feff finished -----------");

            foreach (string s in Directory.GetFiles(Directory.GetCurrentDirectory(), "feff*.dat"))
            {
                string s1 = Path.GetFileName(s);
                string s2 = "../feffdat/" + Path.GetFileName(s.Replace("feff", "ff02"));
                MoveFile_overwrite(s1, s2);
            }

            MoveFile_overwrite("chi.dat", "../chidat/chi_Kd.dat");
            MoveFile_overwrite("xmu.dat", "../xmudat/xmu_Kd.dat");
            File.Copy("paths.dat", "../chidat/path00_Kd.dat", true);
            Directory.SetCurrentDirectory("../");
            GC.Collect();
        }
        private void RunFeffK_ChangeCriteria(double start = 1.5, double end = 0.3, double step = 0.03)
        {
            //_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
            //      CRITERIA 0.3 to 1.5 step 0.03       K               _/
            //_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
            log.AddL(string.Format("CRITERIA {0} to {1}", start, end));
            Directory.SetCurrentDirectory("K");
            File.Copy("feff.inp", "feff.inp.original", true);
            log.AddL("copy feff.inp.original");

            for (int i = 0; start - step * i >= end; i++)
            {
                ReplaceCONTROL_and_CRITERIA(start - step * i);
                //
                log.AddL("run feff CRITERIA : " + (start - step * i));
                RunProgram(ExeFileDirectory + "/feff83_mod");
                log.AddL("---------- feff finished -----------");

                MoveFile_overwrite("chi.dat", "../feffdat/chi_" + String.Format("{0:00}", i) + ".dat");


                if (!Directory.Exists("test"))
                    Directory.CreateDirectory("test");
                MoveFile_overwrite("feff.inp", "test/feff" + (start - step * i) + ".inp");
            }
//            Directory.SetCurrentDirectory("../");
        }
        //smoothを走らせる
        private void RunSmooth(bool throw_exception = false)
        {
            try 
            {
                Directory.SetCurrentDirectory("xmudat");
                if (!File.Exists(txt_feff_smooth.Text)&& !File.Exists("smooth.inp"))
                {
                    log.AddL("Error!:smooth.inp is not exist");
                    throw new Exception("smooth.inp is not exist");
                }
                if( IsSameFileName( txt_feff_smooth.Text , "smooth.inp" ) == false 
                    && string.IsNullOrEmpty(txt_feff_smooth.Text) == false)
                    File.Copy(txt_feff_smooth.Text, "smooth.inp", true);

                if (!File.Exists("xmu_K.dat") || !File.Exists("xmu_Kd.dat"))
                {
                    log.AddL("xmu_K.dat or xmu_Kd.dat is not exist");
                    throw new Exception("xmu_K.dat or xmu_Kd.dat is not exist");
                }

                File.Copy("xmu_K.dat", "xmu.dat",true);
                RunProgram(ExeFileDirectory + "/smooth");
                MoveFile_overwrite("smooth_out.dat", "../feffdat/mu0_av.dat");
                Directory.SetCurrentDirectory("../");
            }
            catch(Exception e)
            {
                if (throw_exception) 
                    throw new Exception(e.Message);
            }
        }
        //chimodを走らせる
        private void RunChimodTxtK(bool throw_exception = false)
        {
            try
            {
                //ファイルの存在確認
                if (!File.Exists("chidat/chi_K.dat") || !File.Exists("chidat/chi_Kd.dat"))
                {
                    log.AddL("Error!:chi_K.dat or chi_Kd.dat is not exist");
                    throw new Exception("chi_K.dat or chi_Kd.dat is not exist");
                }
                //chimodtxtKの中身
                Directory.SetCurrentDirectory("chidat");
                
                File.Copy("chi_K.dat", "chi1.dat", true);
                File.Copy("chi_Kd.dat", "chi2.dat", true);

                log.AddL("----------- start chimod ----------------");
                RunProgram(ExeFileDirectory + "/chimod12");
                RunProgram(ExeFileDirectory + "/chimod12d");
                log.AddL("----------- end chimod ----------------");

                if (File.Exists("chi1log.dat"))
                {
                    log.AddL( File.ReadAllText("chi1log.dat", BTMainForm.CharEncode) );
                }
                if (File.Exists("chi12log.dat"))
                {
                    log.AddL(File.ReadAllText("chi12log.dat", BTMainForm.CharEncode));
                }
                File.Copy("chi1m.dat", "../feffdat/chi1m.dat", true);
                File.Copy("chi2m.dat", "../feffdat/chi2m.dat", true);
                Directory.SetCurrentDirectory("../");
            }
            catch (Exception e)
            {
                if (throw_exception) 
                    throw new Exception(e.Message);
            }
        }

    }
}
