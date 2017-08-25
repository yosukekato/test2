using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using Point = System.Drawing.Point;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

//BTinp.datを作るためのウインドウ。
namespace BTWrapper
{
   /* public partial class BTCreateWindow : Form
    {
        List<ParamControl> param = new List<ParamControl>();
        List<Label> labels = new List<Label>();
        List<TextBox> txts = new List<TextBox>();
        List<Button> bts = new List<Button>();
        string filename = "";
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }


        #region ValueNames
        string[][] paramnames = 
        {
            new string[]{ "itermax","mxpath", "mxspath", "mc3path", "kni", "ircorr", "itrunc", "inpex", 
                "minxq","malphopt", "n0bkg", "ipbkg", "iamatc", "nord", "ircfct", "iboot","lalph"},
            new string[]{
                "bkgw", "dels02", "dele0", "delrp", "delsp", "delc3", "deldg", "delstd"},
            new string[]{
                "experr", "erre1", "erre2", "erre12", "erre3", "erre4", "erre34", "errk1", "errk2",
                "errk12","errk3", "errk4", "errk34", "errk5", "errk6", "errk56"},
            new string[]{
                "nfed", "ifed", "fedt", "fedf1", "fedf2", "fedf3", "fedf4", "delfed1", 
                "delfed2", "delfed3", "delfed4", "debt", "deldebt", "rsh1", "rsh2", "rsh3", "o2m"},
            new string[]{
                "fedf5", "delfed5", "fedf6", "delfed6", "fedf7", "delfed7", "rsh5", "rsh6", "rsh7"},

        };

        string[] line2param = new string[]{
                "itermax","mxpath", "mxspath", "mc3path", "kni", "ircorr", "itrunc", "inpex", 
                "minxq","malphopt", "n0bkg", "ipbkg", "iamatc", "nord", "ircfct", "iboot","lalph"
            };
        string[] line3param = new string[]{
                "bkgw", "dels02", "dele0", "delrp", "delsp", "delc3", "deldg", "delstd"
            };
        string[] line4param = new string[]{
                "q_min", "errxla", "erramp", "errpha", "errrad", "errsig", "cstd", "S02", "E0"
            };
        string[] line5param = new string[]{
                "experr", "erre1", "erre2", "erre12", "erre3", "erre4", "erre34", "errk1", "errk2",
                "errk12","errk3", "errk4", "errk34", "errk5", "errk6", "errk56"
            };
        string[] line6param = new string[]{
                "nfed", "ifed", "fedt", "fedf1", "fedf2", "fedf3", "fedf4", "delfed1", 
                "delfed2", "delfed3", "delfed4", "debt", "deldebt", "rsh1", "rsh2", "rsh3", "o2m"
            };
        string[] line6aparam = new string[]{
                "fedf5", "delfed5", "fedf6", "delfed6", "fedf7", "delfed7", "rsh5", "rsh6", "rsh7"
            };
        string[] line7param = new string[]{
                "mum", "ism", "e0l1", "e0l2", "e0l3", "osca", "oscr", "oscs"
            };
        string[] line8param = new string[]{
                "ifilt", "qwin", "rwin", "qwin1", "qwin2", "rwin1", "rwin2", "nqfft", "ftrm"
            };
        string[] line9param = new string[]{
                "npot", "cpotx(i)"
            };
        string[] line10param = new string[]{
                "lpx", "dparlp0x(i)"
            };
        string[] line11param = new string[]{
                "iwtf", "nwtf(i)", "mwtf", "wtfs(i)"
            };
        string[] line12param = new string[]{
                "mix", "mixdir"
            };
        #endregion
        public BTCreateWindow()
        {
            InitializeComponent();
            this.ClientSize = new Size(500, 550);
            tabControl1.Size = new Size(480, 530);
            InitializeTab1();
            InitializeTab2();
            InitializeTab3();
            InitializeButtons();

            InitializeTextBoxes();

        }
        //テキストボックスの値をデフォルトの値(Cu K端)で埋める
        private void InitializeTextBoxes()
        {
            //テキストボックスにデフォルトの値を入れる
            Assembly asm = Assembly.GetExecutingAssembly();
            StreamReader sr = new StreamReader(asm.GetManifestResourceStream("BTWrapper.BTinp_orig.txt"), BTMainForm.CharEncode);
            
            ReadBTInpData(ref sr);
            sr.Close();
        }
        //BTInpファイルを外部から読み込んでテキストボックスに格納
        public void ReadBTInpData(ref StreamReader sr)
        {
            //line1
            foreach (TextBox b in txts)
            {
                if (b.Name == "CommentBox")
                {
                    b.Text = sr.ReadLine();
                    break;
                }
            }
            //line2以降
            int NextStart = 0;
            int NextNum = line2param.Count();
            char[] delimiter = { ' ', '\t' };
            ReadDefNum(ref NextStart, line2param.Count(), ref sr);
            ReadDefNum(ref NextStart, line3param.Count(), ref sr);
            ReadDefNum(ref NextStart, line4param.Count(), ref sr);
            ReadDefNum(ref NextStart, line5param.Count(), ref sr);
            ReadDefNum(ref NextStart, line6param.Count(), ref sr);
            if (param[NextStart - line6param.Count() + 1].Value() > 0)
                ReadDefNum(ref NextStart, line6aparam.Count(), ref sr);
            else
            {
                for (int i = 0; i < line6aparam.Count(); i++)
                {
                    param[NextStart + i].SetParam("0");
                }
                NextStart += line6aparam.Count();
            }
            ReadDefNum(ref NextStart, line7param.Count(), ref sr);
            ReadDefNum(ref NextStart, line8param.Count(), ref sr);
            //Line9 ~ 11は特殊
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < s.Count(); i++)
                {
                    if (i == 0)
                        param[NextStart + i].SetParam(s[i]);
                    else if (i == 1)
                    {
                        param[NextStart + 1].SetParam(s[i] + " ");
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                    else
                    {
                        param[NextStart + 1].AddParam(s[i]);
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                }
                NextStart += line9param.Count();
            }
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < s.Count(); i++)
                {
                    if (i == 0)
                        param[NextStart + i].SetParam(s[i]);
                    else if (i == 1)
                    {
                        param[NextStart + 1].SetParam(s[i] + " ");
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                    else
                    {
                        param[NextStart + 1].AddParam(s[i]);
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                }
                NextStart += line10param.Count();
            }
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                int nwtf_num = int.Parse(s[0]);
                if (nwtf_num <= 0) nwtf_num = 1;
                int wtfs_num = int.Parse(s[1+nwtf_num]);
                if (wtfs_num <= 0) wtfs_num = 1;
                param[NextStart + 0].SetParam(s[0]);
                for (int i = 1; i < 1+nwtf_num; i++)
                {
                    if (i == 1)
                        param[NextStart + 1].SetParam(s[i]);
                    else
                        param[NextStart + 1].AddParam(s[i]);
                }
                param[NextStart + 2].SetParam(s[1 + nwtf_num]);
                for (int i = 1 + nwtf_num; i < 1 + nwtf_num + wtfs_num; i++)
                {
                    if (i == 1)
                        param[NextStart + 3].SetParam(s[i]);
                    else
                        param[NextStart + 3].AddParam(s[i]);
                }


                NextStart += line11param.Count();
            }

            //ここまで
            ReadDefNum(ref NextStart, line12param.Count(), ref sr);

        }
        //内部用。うまく格納するための関数
        private void ReadDefNum(ref int NextStartPoint, int NextMaxNum, ref StreamReader sr)
        {
            char[] delimiter = { ' ', '\t' };
            string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Count() && i+NextStartPoint < param.Count() ; i++)
            {
                param[NextStartPoint + i].SetParam(s[i]);
            }
            NextStartPoint += NextMaxNum;
        }


        //Tab1,Line1～4の初期化
        private void InitializeTab1()
        {
            Size deflabelsize = new Size(35, 12);
            labels.Add( ControlFactory.Create<Label>(
                new Point(5,5) , deflabelsize , "Line1:Comment" , "Comment" , 0 ) );
            tabPage1.Controls.Add(labels.Last());

            txts.Add(ControlFactory.Create<TextBox>(
                new Point(5, 25), new Size(460, 19), "", "CommentBox", 1));
            tabPage1.Controls.Add(txts.Last());

            int LineParamYStart = 55;
            int LineParamXInterval = 150;
            for (int i = 0; i < 3; i++)
            {
                labels.Add( ControlFactory.Create<Label>( new Point(LineParamXInterval*i, LineParamYStart) 
                    , deflabelsize , "Line" + (i+2).ToString(),null,0));
                tabPage1.Controls.Add(labels.Last());
            }

            LineParamYStart += 25;
            for(int i=0;i<line2param.Count();i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line2param[i], this.tabPage1));
            }
            for (int i = 0; i < line3param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval, LineParamYStart + i * 20, line3param[i], this.tabPage1));
            }
            for (int i = 0; i < line4param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval*2, LineParamYStart + i * 20, line4param[i], this.tabPage1));
            }

        }
        //Tab2.Line5～7(6a含む)の初期化
        private void InitializeTab2()
        {
            Size deflabelsize = new Size(35,12);
            int LineParamYStart = 25;
            int LineParamXInterval = 150;
            for (int i = 0; i < 3; i++)
            {
                labels.Add( ControlFactory.Create<Label>( new Point(LineParamXInterval * i, LineParamYStart)
                    , deflabelsize , "Line" + (i + 5).ToString() , null , 0 ) );
                tabPage2.Controls.Add(labels.Last());
            }
            LineParamYStart += 25;
            for (int i = 0; i < line5param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line5param[i], this.tabPage2));
            }
            for (int i = 0; i < line6param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval, LineParamYStart + i * 20, line6param[i], this.tabPage2));
            }
            //Line6a


            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * 2, 5 + line7param.Count() * 20 + LineParamYStart)
                    , deflabelsize, "Line6a", null, 0));
            tabPage2.Controls.Add(labels.Last());

            for (int i = 0; i < line6aparam.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval * 2, 30 + line7param.Count() * 20 + LineParamYStart + i * 20, line6aparam[i], this.tabPage2));
                param.Last().Enable(false);
            }
            for (int i = 0; i < line7param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval * 2, LineParamYStart + i * 20, line7param[i], this.tabPage2));
            }



        }
        //Tab2.Line8～12の初期化
        private void InitializeTab3()
        {
            Size deflabelsize = new Size(35, 12);
            int LineParamYStart = 25;
            int LineParamXInterval = 150;
            for (int i = 0; i < 2; i++)
            {
                labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * i, LineParamYStart)
                    , deflabelsize, "Line" + (i + 8).ToString(), null, 0));
                tabPage3.Controls.Add(labels.Last());
            }
            LineParamYStart += 25;
            for (int i = 0; i < line8param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line8param[i], this.tabPage3));
            }

            //Line9は特殊
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart        , line9param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart +  20  , line9param[1], this.tabPage3,300));

            //Line10も特殊
            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval, LineParamYStart + 20 * 3 + 5)
                    , deflabelsize, "Line10", null, 0));
            tabPage3.Controls.Add(labels.Last());

            param.Add(new ParamControl(LineParamXInterval , LineParamYStart + 20*3+30   , line10param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval , LineParamYStart + 20*4+30   , line10param[1], this.tabPage3,300));

            //Line11も(ry
            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval, LineParamYStart + 20 * 8 + 5)
                    , deflabelsize, "Line11", null, 0));
            tabPage3.Controls.Add(labels.Last());

            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 8 + 30, line11param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 9 + 30, line11param[1], this.tabPage3, 300));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 11 + 35, line11param[2], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 12 + 35, line11param[3], this.tabPage3, 300));

            //Line12はLine8の下に持ってくる
            labels.Add(ControlFactory.Create<Label>(new Point(0, LineParamYStart + 20 * line8param.Count() + 25)
                    , deflabelsize, "Line12", null, 0));
            tabPage3.Controls.Add(labels.Last());
            for (int i = 0; i < line12param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + (i + line8param.Count()) * 20 + 50, line12param[i], this.tabPage3));
            }


        }
        //ボタンとか
        private void InitializeButtons()
        {
            Size defsize = new Size(100,30);

            for (int i = 0; i < 3; i++)
            {
                bts.Add( ControlFactory.CreateButton( new Point(360, 460), defsize , 
                    "Create BTinp.dat","bt_BTinpCreate", new EventHandler(this.CreateBTinp),1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());

                bts.Add(ControlFactory.CreateButton(new Point(240, 460), defsize,
                    "Cancel", "bt_BTinpCancel", new EventHandler(this.Cancel), 1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());

                bts.Add(ControlFactory.CreateButton(new Point(120, 460), defsize,
                    "Read File", "bt_BTinpRead", new EventHandler(this.ReadFile), 1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());
            }
        }
        //内部用イベントハンドラ。ボタンなど
        private void CreateBTinp(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "dat file|*.dat";
            sfd.Title = "save BTinp.dat";
            sfd.FileName = "BTinp.dat";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, BTMainForm.CharEncode))
                {
                    //line1
                    foreach (TextBox b in txts)
                    {
                        if (b.Name == "CommentBox")
                        {
                            sw.Write(b.Text + "\n");
                            break;
                        }
                    }
                    //line2～
                    //サイズで改行
                    int[] nextsize = new int[]{ line2param.Count(),line3param.Count(),line4param.Count()
                    ,line5param.Count(),line6param.Count(),line6aparam.Count(),line7param.Count(),line8param.Count()
                    ,line9param.Count(),line10param.Count(),line11param.Count(),line12param.Count()};
                    int next = nextsize[0];
                    int nextline = 1;
                    for (int i = 0; i < param.Count; i++)
                    {
                        sw.Write(param[i].ToString());
                        
                        if (i == next - 1)
                        {
                            sw.Write("\n");
                            if (nextline == 5&&param[next+1-line6param.Count()].Value()==0)
                            {
                                i += nextsize[nextline];
                                next += nextsize[nextline];
                                nextline++;
                            }
                            if (nextline < nextsize.Count())
                            {
                                next += nextsize[nextline];
                                nextline++;
                            }
                        }
                        else
                            sw.Write(' ');
                    }
                }
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReadFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "BTinp.dat";
            ofd.Filter = "dat file|*.dat";
            ofd.Title = "Read BTinp.dat from existing file";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, BTMainForm.CharEncode);
                filename = ofd.FileName;
                ReadBTInpData(ref sr);
                sr.Close();
            }
        }
    }*/
    public partial class BTCreateWindow : Form
    {
        List<ParamControl> param = new List<ParamControl>();
        List<Label> labels = new List<Label>();
        List<TextBox> txts = new List<TextBox>();
        List<Button> bts = new List<Button>();
        string filename = "";
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }


        #region ValueNames
        string[][] paramnames = 
        {
            new string[]{ "itermax","mxpath", "mxspath", "mc3path", "kni", "ircorr", "itrunc", "inpex", 
                "minxq","malphopt", "n0bkg", "ipbkg", "iamatc", "nord", "ircfct", "iboot","lalph"},
            new string[]{
                "bkgw", "dels02", "dele0", "delrp", "delsp", "delc3", "deldg", "delstd"},
            new string[]{
                "experr", "erre1", "erre2", "erre12", "erre3", "erre4", "erre34", "errk1", "errk2",
                "errk12","errk3", "errk4", "errk34", "errk5", "errk6", "errk56"},
            new string[]{
                "nfed", "ifed", "fedt", "fedf1", "fedf2", "fedf3", "fedf4", "delfed1", 
                "delfed2", "delfed3", "delfed4", "debt", "deldebt", "rsh1", "rsh2", "rsh3", "o2m"},
            new string[]{
                "fedf5", "delfed5", "fedf6", "delfed6", "fedf7", "delfed7", "rsh5", "rsh6", "rsh7"},

        };

        string[] line2param = new string[]{
                "itermax","mxpath", "mxspath", "mc3path", "kni", "ircorr", "itrunc", "inpex", 
                "minxq","malphopt", "n0bkg", "ipbkg", "iamatc", "nord", "ircfct", "iboot","lalph"
            };
        string[] line3param = new string[]{
                "bkgw", "dels02", "dele0", "delrp", "delsp", "delc3", "deldg", "delstd"
            };
        string[] line4param = new string[]{
                "q_min", "errxla", "erramp", "errpha", "errrad", "errsig", "cstd", "S02", "E0"
            };
        string[] line5param = new string[]{
                "experr", "erre1", "erre2", "erre12", "erre3", "erre4", "erre34", "errk1", "errk2",
                "errk12","errk3", "errk4", "errk34", "errk5", "errk6", "errk56"
            };
        string[] line6param = new string[]{
                "nfed", "ifed", "fedt", "fedf1", "fedf2", "fedf3", "fedf4", "delfed1", 
                "delfed2", "delfed3", "delfed4", "debt", "deldebt", "rsh1", "rsh2", "rsh3", "o2m"
            };
        string[] line6aparam = new string[]{
                "fedf5", "delfed5", "fedf6", "delfed6", "fedf7", "delfed7", "rsh5", "rsh6", "rsh7"
            };
        string[] line7param = new string[]{
                "mum", "ism", "e0l1", "e0l2", "e0l3", "osca", "oscr", "oscs"
            };
        string[] line8param = new string[]{
                "ifilt", "qwin", "rwin", "qwin1", "qwin2", "rwin1", "rwin2", "nqfft", "ftrm"
            };
        string[] line9param = new string[]{
                "npot", "cpotx(i)"
            };
        string[] line10param = new string[]{
                "lpx", "dparlp0x(i)"
            };
        string[] line11param = new string[]{
                "iwtf", "nwtf(i)", "mwtf", "wtfs(i)"
            };
        string[] line12param = new string[]{
                "mix", "mixdir"
            };
        #endregion
        public BTCreateWindow()
        {
            InitializeComponent();
            this.ClientSize = new Size(500, 550);
            tabControl1.Size = new Size(480, 530);
            InitializeTab1();
            InitializeTab2();
            InitializeTab3();
            InitializeButtons();

            InitializeTextBoxes();

        }
        //テキストボックスの値をデフォルトの値(Cu K端)で埋める
        private void InitializeTextBoxes()
        {
            //テキストボックスにデフォルトの値を入れる
            Assembly asm = Assembly.GetExecutingAssembly();
            StreamReader sr = new StreamReader(asm.GetManifestResourceStream("test2.BTinp_orig.txt"), BTMainForm.CharEncode);

            ReadBTInpData(ref sr);
            sr.Close();
        }
        //BTInpファイルを外部から読み込んでテキストボックスに格納
        public void ReadBTInpData(ref StreamReader sr)
        {
            //line1
            foreach (TextBox b in txts)
            {
                if (b.Name == "CommentBox")
                {
                    b.Text = sr.ReadLine();
                    break;
                }
            }
            //line2以降
            int NextStart = 0;
            int NextNum = line2param.Count();
            char[] delimiter = { ' ', '\t' };
            ReadDefNum(ref NextStart, line2param.Count(), ref sr);
            ReadDefNum(ref NextStart, line3param.Count(), ref sr);
            ReadDefNum(ref NextStart, line4param.Count(), ref sr);
            ReadDefNum(ref NextStart, line5param.Count(), ref sr);
            ReadDefNum(ref NextStart, line6param.Count(), ref sr);
            if (param[NextStart - line6param.Count() + 1].Value() > 0)
                ReadDefNum(ref NextStart, line6aparam.Count(), ref sr);
            else
            {
                for (int i = 0; i < line6aparam.Count(); i++)
                {
                    param[NextStart + i].SetParam("0");
                }
                NextStart += line6aparam.Count();
            }
            ReadDefNum(ref NextStart, line7param.Count(), ref sr);
            ReadDefNum(ref NextStart, line8param.Count(), ref sr);
            //Line9 ~ 11は特殊
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < s.Count(); i++)
                {
                    if (i == 0)
                        param[NextStart + i].SetParam(s[i]);
                    else if (i == 1)
                    {
                        param[NextStart + 1].SetParam(s[i] + " ");
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                    else
                    {
                        param[NextStart + 1].AddParam(s[i]);
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                }
                NextStart += line9param.Count();
            }
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < s.Count(); i++)
                {
                    if (i == 0)
                        param[NextStart + i].SetParam(s[i]);
                    else if (i == 1)
                    {
                        param[NextStart + 1].SetParam(s[i] + " ");
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                    else
                    {
                        param[NextStart + 1].AddParam(s[i]);
                        if (i != s.Count() - 1)
                            param[NextStart + 1].AddParam(" ");
                    }
                }
                NextStart += line10param.Count();
            }
            {
                string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                int nwtf_num = int.Parse(s[0]);
                if (nwtf_num <= 0) nwtf_num = 1;
                int wtfs_num = int.Parse(s[1 + nwtf_num]);
                if (wtfs_num <= 0) wtfs_num = 1;
                param[NextStart + 0].SetParam(s[0]);
                for (int i = 1; i < 1 + nwtf_num; i++)
                {
                    if (i == 1)
                        param[NextStart + 1].SetParam(s[i]);
                    else
                        param[NextStart + 1].AddParam(s[i]);
                }
                param[NextStart + 2].SetParam(s[1 + nwtf_num]);
                for (int i = 1 + nwtf_num; i < 1 + nwtf_num + wtfs_num; i++)
                {
                    if (i == 1)
                        param[NextStart + 3].SetParam(s[i]);
                    else
                        param[NextStart + 3].AddParam(s[i]);
                }


                NextStart += line11param.Count();
            }

            //ここまで
            ReadDefNum(ref NextStart, line12param.Count(), ref sr);

        }
        //内部用。うまく格納するための関数
        private void ReadDefNum(ref int NextStartPoint, int NextMaxNum, ref StreamReader sr)
        {
            char[] delimiter = { ' ', '\t' };
            string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Count() && i + NextStartPoint < param.Count(); i++)
            {
                param[NextStartPoint + i].SetParam(s[i]);
            }
            NextStartPoint += NextMaxNum;
        }


        //Tab1,Line1～4の初期化
        private void InitializeTab1()
        {
            Size deflabelsize = new Size(35, 12);
            labels.Add(ControlFactory.Create<Label>(
                new Point(5, 5), deflabelsize, "Line1:Comment", "Comment", 0));
            tabPage1.Controls.Add(labels.Last());

            txts.Add(ControlFactory.Create<TextBox>(
                new Point(5, 25), new Size(460, 19), "", "CommentBox", 1));
            tabPage1.Controls.Add(txts.Last());

            int LineParamYStart = 55;
            int LineParamXInterval = 150;
            for (int i = 0; i < 3; i++)
            {
                labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * i, LineParamYStart)
                    , deflabelsize, "Line" + (i + 2).ToString(), null, 0));
                tabPage1.Controls.Add(labels.Last());
            }

            LineParamYStart += 25;
            for (int i = 0; i < line2param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line2param[i], this.tabPage1));
            }
            for (int i = 0; i < line3param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval, LineParamYStart + i * 20, line3param[i], this.tabPage1));
            }
            for (int i = 0; i < line4param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval * 2, LineParamYStart + i * 20, line4param[i], this.tabPage1));
            }

        }
        //Tab2.Line5～7(6a含む)の初期化
        private void InitializeTab2()
        {
            Size deflabelsize = new Size(35, 12);
            int LineParamYStart = 25;
            int LineParamXInterval = 150;
            for (int i = 0; i < 3; i++)
            {
                labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * i, LineParamYStart)
                    , deflabelsize, "Line" + (i + 5).ToString(), null, 0));
                tabPage2.Controls.Add(labels.Last());
            }
            LineParamYStart += 25;
            for (int i = 0; i < line5param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line5param[i], this.tabPage2));
            }
            for (int i = 0; i < line6param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval, LineParamYStart + i * 20, line6param[i], this.tabPage2));
            }
            //Line6a


            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * 2, 5 + line7param.Count() * 20 + LineParamYStart)
                    , deflabelsize, "Line6a", null, 0));
            tabPage2.Controls.Add(labels.Last());

            for (int i = 0; i < line6aparam.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval * 2, 30 + line7param.Count() * 20 + LineParamYStart + i * 20, line6aparam[i], this.tabPage2));
                param.Last().Enable(false);
            }
            for (int i = 0; i < line7param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval * 2, LineParamYStart + i * 20, line7param[i], this.tabPage2));
            }



        }
        //Tab2.Line8～12の初期化
        private void InitializeTab3()
        {
            Size deflabelsize = new Size(35, 12);
            int LineParamYStart = 25;
            int LineParamXInterval = 150;
            for (int i = 0; i < 2; i++)
            {
                labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval * i, LineParamYStart)
                    , deflabelsize, "Line" + (i + 8).ToString(), null, 0));
                tabPage3.Controls.Add(labels.Last());
            }
            LineParamYStart += 25;
            for (int i = 0; i < line8param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line8param[i], this.tabPage3));
            }

            //Line9は特殊
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart, line9param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20, line9param[1], this.tabPage3, 300));

            //Line10も特殊
            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval, LineParamYStart + 20 * 3 + 5)
                    , deflabelsize, "Line10", null, 0));
            tabPage3.Controls.Add(labels.Last());

            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 3 + 30, line10param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 4 + 30, line10param[1], this.tabPage3, 300));

            //Line11も(ry
            labels.Add(ControlFactory.Create<Label>(new Point(LineParamXInterval, LineParamYStart + 20 * 8 + 5)
                    , deflabelsize, "Line11", null, 0));
            tabPage3.Controls.Add(labels.Last());

            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 8 + 30, line11param[0], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 9 + 30, line11param[1], this.tabPage3, 300));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 11 + 35, line11param[2], this.tabPage3));
            param.Add(new ParamControl(LineParamXInterval, LineParamYStart + 20 * 12 + 35, line11param[3], this.tabPage3, 300));

            //Line12はLine8の下に持ってくる
            labels.Add(ControlFactory.Create<Label>(new Point(0, LineParamYStart + 20 * line8param.Count() + 25)
                    , deflabelsize, "Line12", null, 0));
            tabPage3.Controls.Add(labels.Last());
            for (int i = 0; i < line12param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + (i + line8param.Count()) * 20 + 50, line12param[i], this.tabPage3));
            }


        }
        //ボタンとか
        private void InitializeButtons()
        {
            Size defsize = new Size(100, 30);

            for (int i = 0; i < 3; i++)
            {
                bts.Add(ControlFactory.CreateButton(new Point(360, 460), defsize,
                    "Create BTinp.dat", "bt_BTinpCreate", new EventHandler(this.CreateBTinp), 1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());

                bts.Add(ControlFactory.CreateButton(new Point(240, 460), defsize,
                    "Cancel", "bt_BTinpCancel", new EventHandler(this.Cancel), 1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());

                bts.Add(ControlFactory.CreateButton(new Point(120, 460), defsize,
                    "Read File", "bt_BTinpRead", new EventHandler(this.ReadFile), 1));
                tabControl1.TabPages["tabPage" + (i + 1)].Controls.Add(bts.Last());
            }
        }
        //内部用イベントハンドラ。ボタンなど
        private void CreateBTinp(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "dat file|*.dat";
            sfd.Title = "save BTinp.dat";
            sfd.FileName = "BTinp.dat";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, BTMainForm.CharEncode))
                {
                    //line1
                    foreach (TextBox b in txts)
                    {
                        if (b.Name == "CommentBox")
                        {
                            sw.Write(b.Text + "\n");
                            break;
                        }
                    }
                    //line2～
                    //サイズで改行
                    int[] nextsize = new int[]{ line2param.Count(),line3param.Count(),line4param.Count()
                    ,line5param.Count(),line6param.Count(),line6aparam.Count(),line7param.Count(),line8param.Count()
                    ,line9param.Count(),line10param.Count(),line11param.Count(),line12param.Count()};
                    int next = nextsize[0];
                    int nextline = 1;
                    for (int i = 0; i < param.Count; i++)
                    {
                        sw.Write(param[i].ToString());

                        if (i == next - 1)
                        {
                            sw.Write("\n");
                            if (nextline == 5 && param[next + 1 - line6param.Count()].Value() == 0)
                            {
                                i += nextsize[nextline];
                                next += nextsize[nextline];
                                nextline++;
                            }
                            if (nextline < nextsize.Count())
                            {
                                next += nextsize[nextline];
                                nextline++;
                            }
                        }
                        else
                            sw.Write(' ');
                    }
                }
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReadFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "BTinp.dat";
            ofd.Filter = "dat file|*.dat";
            ofd.Title = "Read BTinp.dat from existing file";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, BTMainForm.CharEncode);
                filename = ofd.FileName;
                ReadBTInpData(ref sr);
                sr.Close();
            }
        }
    }

    class ValueControl
    {
        TextBox txt;
        Label label;
        public ValueControl(int x, int y, string s, Control parent, int txtbox_extend = -1)
        {
            this.label = ControlFactory.Create<Label>(new Point(x, y), new Size(35, 12), s, s, 0);
            
            if (txtbox_extend > 0)
            {
                this.txt = ControlFactory.Create<TextBox>( new Point(x, y + 20) , 
                    new Size(txtbox_extend, 19) ,  "txt_" + s ,  "txt_" + s , 1 );
            }
            else
            {
                this.txt = ControlFactory.Create<TextBox>( new Point(x + 60, y) , 
                    new Size(70, 19) ,  "txt_" + s ,  "txt_" + s , 1 );
            }
            parent.Controls.Add(this.label);
            parent.Controls.Add(this.txt);
            // 
            parent.ResumeLayout(false);
        }
        /// <summary>
        /// Enable this value controls(textbox + label)
        /// </summary>
        public bool Enable
        {
            get { return txt.Enabled; }
            set { txt.Enabled = label.Enabled = value; }
        }
        /// <summary>
        /// set/get param value by string
        /// </summary>
        public string Value
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }
        public int IntValue
        {
            get 
            { 
                try { return int.Parse(txt.Text); } 
                catch { return 0; } 
            }
        }
        public override string ToString()
        {
            return txt.Text;
        }
    }

    /*class LineParams
    {
        /// <summary>
        /// テキストボックス配置パターン
        /// DEFAULT:ラベル＋下にテキストボックス
        /// LONG：ラベル：下にテキストボックス（長い
        /// ARGS：ラベル＋下にテキストボックス１は短く、その次は可変長なので長く
        /// </summary>
        public enum Arrangement
        {
            DEFAULT,
            LONG,
            ARGS,   
        };
        Label linelabel;
        public string LineName 
        {
            get { return linelabel.Text; }
            set { linelabel.Text = value; }
        }
        string[] paramnames;
        List<ValueControl> paramvalues = new List<ValueControl>();
        public LineParams(string[] paramnames,string linename,int x,int y,Arrangement ar)
        {
            linelabel = ControlFactory.Create<Label>(new Point(x, y), new Size(35, 12),
                linename, linename, 0);
            this.paramnames = paramnames;
            
            string[] s = 
            for (int i = 0; i < paramvalues.Length; i++)
            {
                paramvalues[i] = new ValueControl( x , y + 20 , 
            }

        }
        void SaveThisLine(StreamWriter sw, Encoding e = Encoding.Default);
        void LoadThisLine(string s)
        {
            string[] strs = s.Split(new char[] { ' ', '\t' });
            for (int i = 0; i < strs.Length; i++)
            {
                paramvalues.Add( new ValueControl( 
            }
        }
        public bool Enable { get; set; }

    }*/


    public class ControlFactory
    {
        public static T Create<T>(Point location, Size size, string text, string name = null,
            int tabindex = 0) where T : Control, new()
        {
            T control = new T();
            control.AutoSize = true;
            control.Location = location;
            control.Size = size;
            control.TabIndex = 0;
            if (name == null)
            {
                control.Text = control.Name = text;
            }
            else
            {
                control.Name = name;
                control.Text = text;
            }
            return control;
        }
        public static Button CreateButton(Point location, Size size, string text,
            string name, EventHandler clickeventfunc, int tabindex = 0)
        {
            Button button = new Button();
            button.Location = location;
            button.Name = name;
            button.Size = size;
            button.TabIndex = 1;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Click += clickeventfunc;
            return button;
        }
    }
}
