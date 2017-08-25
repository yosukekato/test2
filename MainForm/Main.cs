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
        public static Encoding CharEncode = Encoding.GetEncoding("Shift-JIS");
        string ExeFileDirectory;
        LogWindow log = null;
        public BTMainForm()
        {
            InitializeComponent();
            cmb_TargetEdge.SelectedIndex = 0;
            ExeFileDirectory = Directory.GetCurrentDirectory();
            SetCurrentDirectory(ExeFileDirectory);
        }
        private void RunButtonEnable(bool enable)
        {
            bt_runfeff.Enabled = enable;
            bt_chimod.Enabled = enable;
            bt_feff.Enabled = enable;
            bt_smooth.Enabled = enable;
            bt_runexp.Enabled = enable;
            bt_BTMain.Enabled = enable;
        }
        //コンポーネントイベントのみをここに記述
        #region Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetCurrentDirectory(string path)
        {
            txt_workdir.Text = txt_workdir2.Text = txt_workdir3.Text = txt_workdir4.Text = path;
        }
        //カレントディレクトリの変更イベント
        private void bt_ChangeCurrentDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "select work directory\nNow:" + Path.GetFileName(Directory.GetCurrentDirectory());
            fbd.SelectedPath = Directory.GetCurrentDirectory();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Directory.SetCurrentDirectory(fbd.SelectedPath);
                SetCurrentDirectory(fbd.SelectedPath);
                ExeFileDirectory = fbd.SelectedPath;
            }
        }
        #endregion

        #region Feff_Tab_Events
        //feff.inp選択ボタンイベント
        private void bt_feffinp_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "feff.inp";
            ofd.Filter = "feff.inp file|*.inp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txt_feffinp.Text = ofd.FileName;
        }
        private void bt_feff_smooth_Click(object sender, EventArgs e)
        {
            string s = CreateSmoothInp(false);
            if (s != "")
                txt_feff_smooth.Text = s;
        }
        private void bt_feff_smoothsel_Click(object sender, EventArgs e)

        {
            string s = GetOpenFileDialogName("smooth.inp", "inp file|*.inp", "Read smooth.inp from existing file");
            if (s != "") txt_feff_smooth.Text = s;
        }
        private void bt_runfeff_Click(object sender, EventArgs e)
        {
            //K edge
            if (cmb_TargetEdge.SelectedItem.ToString() == "K Edge")
            {
                RunFeffKEdge();
            }
        }

        private string PrepareEachProcess(string start_string)
        {
            RunButtonEnable(false);
            CreateLogWindow();
            log.AddL("run chimod only");
            return Directory.GetCurrentDirectory();
        }
        private void EndEachProcess(string end_string, string currentfolderpath)
        {
            Directory.SetCurrentDirectory(currentfolderpath);
            RunButtonEnable(true);
            log.AddL(end_string);
        }
        private void bt_chimod_Click(object sender, EventArgs e)
        {
            string Current = PrepareEachProcess("run chimod only");

            RunChimodTxtK();

            EndEachProcess("---- process finished ----", Current);
        }
        private void bt_smooth_Click(object sender, EventArgs e)
        {
            string Current = PrepareEachProcess("run smooth only");

            RunSmooth();

            EndEachProcess("---- process finished ----", Current);
        }
        private void bt_feff_Click(object sender, EventArgs e)
        {
            string Current = PrepareEachProcess("run feff only");

            RunFeffK_Only();

            EndEachProcess("---- process finished ----", Current);
        }

        #endregion 

        #region Experiment_Tab_Event
        private void bt_exp_select_Click(object sender, EventArgs e)
        {
            string s = GetOpenFileDialogName("", "dat file|*.dat|all files|*.*", "select experimental data file");
            if (s != "")
            {
                chk_expdatapath.Checked = true;
                txt_exp.Text = s;
            }
        }
        private void bt_selectpreedge_Click(object sender, EventArgs e)
        {
            string s = GetOpenFileDialogName("", "dat file|*.dat|all files|*.*", "select experimental data file with background already substracted");
            if (s != "")
            {
                txt_exp.Text = s;
                chk_subs.Checked = true;
                chk_expdatapath.Checked = true;
            }
        }
        private void bt_runerror_Click(object sender, EventArgs e)
        {
            List<double> ee = new List<double>(), normW = new List<double>();
            double error;
            //try
            //{
                error = double.Parse(txt_error.Text);
                foreach (string line in File.ReadLines(txt_exp.Text, Encoding.ASCII))
                {
                    if (line.StartsWith("#"))   //コメント行は読み飛ばす
                        continue;

                    string[] param = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ee.Add(double.Parse(param[0]));
                    normW.Add(double.Parse(param[1]));
                }

                string filename = Directory.GetCurrentDirectory() + "\\smooth_inp.dat";
                using (StreamWriter sw = new StreamWriter(filename, false, Encoding.ASCII))
                {
                    sw.Write(txt_errcom.Text + "\n");
                    sw.Write("----------------------\n");
                    sw.Write("ee normW error\n");
                    for (int i = 0; i < ee.Count; i++)
                    {
                        sw.Write(ee[i] + " " + normW[i] + " " + normW[i] * error + "\n");
                    }
                }
                chk_error.Checked = true;
                chk_moddata.Checked = true;
                txt_moddata.Text = filename;

            //}
            //catch { MessageBox.Show("エラーが発生しました"); }
        }
        private void bt_moddataselect_Click(object sender, EventArgs e)
        {
            string s = GetOpenFileDialogName("", "dat file|*.dat|all files|*.*", "select experimental data file with background already substracted");
            if (s != "")
                txt_moddata.Text = s;
            chk_subs.Checked = true;
            chk_error.Checked = true;
            chk_moddata.Checked = true;
            chk_expdatapath.Checked = true;
        }
        //バックグラウンド引いて保存する
        private void bt_subpreedge_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_exp.Text))
            {
                BackGroundWindow bw = new BackGroundWindow(txt_exp.Text);
                this.AddOwnedForm(bw);
                bw.ShowDialog();
                if (bw.SaveFile != "")
                {
                    txt_exp.Text = bw.SaveFile;
                    chk_subs.Checked = true;
                    chk_expdatapath.Checked = true;
                }
                   
            }
        }
        private void bt_runexp_Click(object sender, EventArgs e)
        {
            CreateLogWindow();
            string dir = Directory.GetCurrentDirectory();
            if (!Directory.Exists("expdata"))
                Directory.CreateDirectory("expdata");

            try
            {
                RunButtonEnable(false);
                Directory.SetCurrentDirectory("expdata");
                File.Copy(txt_moddata.Text, "smooth_inp.dat", true);
                //ホントはここで名前の前にハイフン入れる処理
                File.Copy(txt_exp_smooth.Text, "smooth.inp", true);

                //smoothを走らせる
                RunProgram(ExeFileDirectory + "/smooth");

                File.Copy("smooth_out.dat", "../feffdat/muexp_av.dat", true);

                Directory.SetCurrentDirectory("../");
                log.AddL("Success");
            }
            catch
            {
                Directory.SetCurrentDirectory(dir);
                log.AddL("Failed");
            }
            finally
            {
                RunButtonEnable(true);
            }
        }
        private void bt_exp_smooth_Click(object sender, EventArgs e)
        {
            string s = CreateSmoothInp(true);
            if (s != "")
                txt_exp_smooth.Text = s;
        }
        private void bt_exp_smoothsel_Click(object sender, EventArgs e)
        {
            string s = GetOpenFileDialogName("smooth.inp", "inp file|*.inp", "Read smooth.inp from existing file");
            if (s != "") txt_exp_smooth.Text = s;
        }
        #endregion

        #region BT_Tab_Event
        private void bt_BTMain_Click(object sender, EventArgs e)
        {
            CreateLogWindow(true);
            RunButtonEnable(false);
            bt_BTMain.Text = "Running...";
            //try
            //{
                File.Copy(txt_btinp.Text, "feffdat/BTinp.dat", true);
                Directory.SetCurrentDirectory("feffdat");
                RunProgram(ExeFileDirectory + "/bt11");
                Directory.SetCurrentDirectory("../");
                log.AddL("BT.exe Success");
            //}
            //catch { log.AddL("BT.exe Failed"); }
            //finally
            //{
                RunButtonEnable(true);
                bt_BTMain.Text = "Run BT main program";
            //}
        }
        private void bt_btinp_Click(object sender, EventArgs e)
        {
            BTCreateWindow btw;
            btw = new BTCreateWindow();
            AddOwnedForm(btw);
            if (btw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_btinp.Text = btw.Filename;
            }
            RemoveOwnedForm(btw);
        }
        private void bt_btinpsel_Click(object sender, EventArgs e)
        {
            string s = GetOpenFileDialogName("BTinp.dat", "dat file|*.dat", "Read BTinp.dat from existing file");
            if (s != "") txt_btinp.Text = s;
        }

        #endregion

        #region Show_Result_Tab_Event

        private void bt_initchart_Click(object sender, EventArgs e)
        {
            //BTdat.datの検索
            if (File.Exists("feffdat/BTdat.dat") == false)
            {
                MessageBox.Show("BTdat.dat is not found");
                return;
            }

            InitDataGraphWindow gsw = new InitDataGraphWindow();
            gsw.Show();
        }

        private void bt_resultchart_Click(object sender, EventArgs e)
        {
            //BTdat.datの検索
            if (File.Exists("feffdat/BTdat.dat") == false)
            {
                MessageBox.Show("BTdat.dat is not found");
                return;
            }

            ResultDataGraphWindow gsw = new ResultDataGraphWindow();
            gsw.Show();
        }

        private void bt_others_Click(object sender, EventArgs e)
        {
            //BTdat.datの検索
            if (File.Exists("feffdat/BTdat.dat") == false)
            {
                MessageBox.Show("BTdat.dat is not found");
                return;
            }
            SelectXYDataWindow sw = new SelectXYDataWindow();
            if (sw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (sw.Xindex == -1 || sw.Yindex == -1)
                {
                    MessageBox.Show("select x,y value");
                    return;
                }
                OtherDataGraphWindow ow = new OtherDataGraphWindow(sw);
                ow.Show();
            }
        }

        private void bt_sn2_Click(object sender, EventArgs e)
        {
            if (File.Exists("feffdat/BTout.dat") == false)
            {
                MessageBox.Show("BTout.dat is not found");
                return;
            }
            Sn2DataGraphWindow sw = new Sn2DataGraphWindow();
            sw.Show();
        }

        private void bt_matrix_Click(object sender, EventArgs e)
        {
            if (File.Exists("feffdat/BTmat.dat") == false)
            {
                MessageBox.Show("BTmat.dat is not found");
                return;
            }
            MatrixDataGraphWindow mw = new MatrixDataGraphWindow();
            mw.Show();
        }

        private void bt_rdf_Click(object sender, EventArgs e)
        {
            //BTdat.datの検索
            if (File.Exists("feffdat/BTdat.dat") == false)
            {
                MessageBox.Show("BTdat.dat is not found");
                return;
            }
            SelectXYDataWindow sw = new SelectXYDataWindow();
            if (sw.SetXY_Manual("R", "g(R)"))
            {
                OtherDataGraphWindow ow = new OtherDataGraphWindow(sw);
                ow.Show();
            }
        }
        #endregion

    }
}
