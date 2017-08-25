using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace BTWrapper
{
    //テキストボックスとラベルをセットにした一変数用
    class ParamControl
    {
        TextBox txt;
        Label label;
        public ParamControl(int x, int y, string s, Control parent, int txtbox_extend = -1)
        {
            this.label = ControlFactory.Create<Label>(new Point(x, y), new Size(35, 12), s, s, 0);  parent.Controls.Add(this.label);
            txt = new TextBox(); if (txtbox_extend > 0)            {                this.txt.Location = new Point(x, y + 20);               this.txt.Size = new Size(txtbox_extend, 19);
            }            else            {                this.txt.Location = new Point(x + 60, y);
                this.txt.Size = new Size(70, 19);            }
            this.txt.Name = "txt_" + s;            this.txt.TabIndex = 1;            parent.Controls.Add(this.txt);            //             parent.ResumeLayout(false);            ToolTip t = new ToolTip();            t.SetToolTip(txt, "ここに説明");
                    }        public void Enable(bool x = true)
        {
            txt.Enabled = x;
            label.Enabled = x;
        }
        public void SetParam(string s)
        {
            txt.Text = s;
        }
        public void AddParam(string s)
        {
            txt.Text += s;
        }
        public int Value()
        {
            try
            {
                return int.Parse(txt.Text);
            }
            catch
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return txt.Text;
        }
    }
    public partial class SmoothCreateWindow : Form
    {
        List<ParamControl> param = new List<ParamControl>();
        List<Label> labels = new List<Label>();
        List<TextBox> txts = new List<TextBox>();
        List<Button> bts = new List<Button>();
        string[] line1param = new string[]{
            "Read from","value2","value3","value4","value5"
        };
        string[] line2param = new string[]{
            "order","E0","k start","k end","value5"
            //,"value6","value7","value8","value9"
        };
        int[] value_readfrom = new int[]{ -2, 1 };
        string filename = "";

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        ComboBox cmb_readfrom;
        public SmoothCreateWindow(bool exp = false)
        {
            InitializeComponent();
            InitializeDesign();
            this.ClientSize = new Size(400, 280);
            Assembly asm = Assembly.GetExecutingAssembly();
            string s = exp ? "test2.smooth_exp.inp" : "test2.smooth_thr.inp";
            StreamReader sr = new StreamReader(asm.GetManifestResourceStream(s), BTMainForm.CharEncode);
            ReadSmoothInp(ref sr);
            sr.Close();
        }
        public void InitializeDesign()
        {
            int LineParamYStart = 5;
            int LineParamXInterval = 200;
            for (int i = 0; i < 2; i++)
            {
                labels.Add(new Label());
                labels.Last().AutoSize = true;
                labels.Last().Location = new System.Drawing.Point(LineParamXInterval * i, LineParamYStart);
                labels.Last().Name = labels.Last().Text = "Line" + (i + 1).ToString();

                labels.Last().Font = new Font(labels.Last().Font.FontFamily, 14); ;
                labels.Last().Size = new System.Drawing.Size(35, 12);
                labels.Last().TabIndex = 0;
                this.Controls.Add(labels.Last());
            }
            LineParamYStart += 40;
            for (int i = 1; i < line1param.Count(); i++)
            {
                param.Add(new ParamControl(0, LineParamYStart + i * 20, line1param[i], this));
            }
            for (int i = 0; i < line2param.Count(); i++)
            {
                param.Add(new ParamControl(LineParamXInterval, LineParamYStart + i * 20, line2param[i], this));
            }

            labels.Add(new Label());
            labels.Last().AutoSize = true;
            labels.Last().Location = new System.Drawing.Point(0, LineParamYStart);
            labels.Last().Name = labels.Last().Text = "ReadFrom";
            labels.Last().Size = new System.Drawing.Size(35, 12);
            labels.Last().TabIndex = 0;
            this.Controls.Add(labels.Last());
            cmb_readfrom = new ComboBox();
            cmb_readfrom.Location = new Point(60, LineParamYStart - 5);
            cmb_readfrom.Size = new Size(100, 19);

            cmb_readfrom.Name = "combo_readfrom";
            cmb_readfrom.TabIndex = 1;
            cmb_readfrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_readfrom.Items.Add("xmu.dat");
            cmb_readfrom.Items.Add("smooth_inp.dat");
            cmb_readfrom.SelectedIndex = 0;
            this.Controls.Add(cmb_readfrom);
            // 
            for (int i = 0; i < 3; i++)
            {
                bts.Add(new Button());
                bts.Last().Location = new System.Drawing.Point(260, 240);
                bts.Last().Name = "bt_SmoothCreate";
                bts.Last().Size = new System.Drawing.Size(100, 30);
                bts.Last().TabIndex = 1;
                bts.Last().Text = "Create smooth";
                bts.Last().UseVisualStyleBackColor = true;
                bts.Last().Click += new System.EventHandler(this.CreateSmooth);
                this.Controls.Add(bts.Last());
                bts.Add(new Button());
                bts.Last().Location = new System.Drawing.Point(140, 240);
                bts.Last().Name = "bt_SmoothCancel";
                bts.Last().Size = new System.Drawing.Size(100, 30);
                bts.Last().TabIndex = 1;
                bts.Last().Text = "Cancel";
                bts.Last().UseVisualStyleBackColor = true;
                bts.Last().Click += new System.EventHandler(this.Cancel);
                this.Controls.Add(bts.Last());
                bts.Add(new Button());
                bts.Last().Location = new System.Drawing.Point(20, 240);
                bts.Last().Name = "bt_SmoothRead";
                bts.Last().Size = new System.Drawing.Size(100, 30);
                bts.Last().TabIndex = 1;
                bts.Last().Text = "Read File";
                bts.Last().UseVisualStyleBackColor = true;
                bts.Last().Click += new System.EventHandler(this.ReadFile);
                this.Controls.Add(bts.Last());
            }
        }
        private void CreateSmooth(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "inp file|*.inp";
            sfd.Title = "save smooth.inp";
            sfd.FileName = "smooth.inp";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, BTMainForm.CharEncode))
                {
                    sw.Write(value_readfrom[cmb_readfrom.SelectedIndex].ToString() + " ");
                    for(int i=0;i<line1param.Count()-1;i++)
                    {
                        sw.Write( param[i].ToString() + (i==line1param.Count()-2?"\n":" ") );
                    }
                    for (int i = 0; i < line2param.Count(); i++)
                    {
                        sw.Write( param[i+line1param.Count()-1].ToString() + (i==line2param.Count()-1?"\n":" "));
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            ofd.FileName = "smooth.inp";
            ofd.Filter = "inpファイル|*.inp";
            ofd.Title = "Read smooth.inp from existing file";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, BTMainForm.CharEncode);
                filename = ofd.FileName;
                ReadSmoothInp(ref sr);
                sr.Close();
            }
        }
        private void ReadSmoothInp(ref StreamReader sr)
        {

            char[] delimiter = { ' ', '\t' };
            string[] s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int value = int.Parse(s[0]);
            for (int i = 0; i < value_readfrom.Count(); i++)
            {
                if (value == value_readfrom[i])
                {
                    cmb_readfrom.SelectedIndex = i;
                    break;
                }
                if (i == value_readfrom.Count() - 1)
                    cmb_readfrom.SelectedIndex = -1;
            }

            for (int i = 0; i < s.Count()-1 && i < param.Count(); i++)
            {
                param[i].SetParam(s[i+1]);
            }
            s = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Count() && i + line1param.Count()-1 < param.Count(); i++)
            {
                param[i+line1param.Count()-1].SetParam(s[i]);
            }


        }
    }
}
