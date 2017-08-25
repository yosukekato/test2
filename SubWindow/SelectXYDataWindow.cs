using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTWrapper
{
    public partial class SelectXYDataWindow : Form
    {
        public int Line { get; set; }
        public int Xindex { get; set; }
        public int Yindex { get; set; }
        public int Errorindex { get; set; }
        public string ParamName { get; set; }
        public string ParamXName { get; set; }
        public string ParamErrName { get; set; }
       // public string 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                bt_OK.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public SelectXYDataWindow()
        {
            InitializeComponent();
        }
        private void cmb_X_SelectedIndexChanged(object sender, EventArgs e)
        {
            int line2startindex = cmb_X.Items.IndexOf("Eexp_1");
            int line3startindex = cmb_X.Items.IndexOf("R");
            int line4startindex = cmb_X.Items.IndexOf("kbg");
            int sel = cmb_X.SelectedIndex;
            ParamXName = cmb_X.SelectedItem.ToString();
            Line = 0;
            cmb_Y.Items.Clear();
            cmb_Error.Items.Clear();
            if (sel < line2startindex)
            {
                for (int i = 0; i < line2startindex; i++)
                {
                    cmb_Y.Items.Add(cmb_X.Items[i]);
                    cmb_Error.Items.Add(cmb_X.Items[i]);
                }
                Line = 0;
            }
            else if (sel < line3startindex)
            {
                for (int i = 0; i < line3startindex - line2startindex; i++)
                {
                    cmb_Y.Items.Add(cmb_X.Items[i + line2startindex]);
                    cmb_Error.Items.Add(cmb_X.Items[i + line2startindex]);
                }
                Line = 1;
            }
            else if (sel < line4startindex)
            {
                for (int i = 0; i < line4startindex - line3startindex; i++)
                {
                    cmb_Y.Items.Add(cmb_X.Items[i + line3startindex]);
                    cmb_Error.Items.Add(cmb_X.Items[i + line3startindex]);
                }
                Line = 2;
            }
            else
            {
                for (int i = 0; i < cmb_X.Items.Count-line4startindex; i++)
                {
                    cmb_Y.Items.Add(cmb_X.Items[i + line4startindex]);
                    cmb_Error.Items.Add(cmb_X.Items[i + line4startindex]);
                }
                Line = 3;
            }
        }
        public bool SetXY_Manual(string x,string y)
        {
            int index = -1;
            index = cmb_X.Items.IndexOf(x);
            if (index < 0) 
                return false;
            cmb_X.SelectedIndex = index;
            index = cmb_Y.Items.IndexOf(y);
            if (index < 0) 
                return false;
            cmb_Y.SelectedIndex = index;
            bt_OK_Click(this, new EventArgs());
            return true;
        }
        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (Line == 0)
            {
                Xindex = cmb_X.SelectedIndex;
                Yindex = cmb_Y.SelectedIndex;
                Errorindex = cmb_Error.SelectedIndex;
            }
            if (Line == 1)
            {
                Xindex = cmb_X.SelectedIndex - cmb_X.Items.IndexOf("Eexp_1");
                Yindex = cmb_Y.SelectedIndex;
                Errorindex = cmb_Error.SelectedIndex;
            }
            if (Line == 2)
            {
                Xindex = cmb_X.SelectedIndex - cmb_X.Items.IndexOf("R");
                Yindex = cmb_Y.SelectedIndex;
                Errorindex = cmb_Error.SelectedIndex;
            }
        }
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        private void cmb_Y_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Y.SelectedIndex >= 0)
            {
                ParamName = cmb_Y.SelectedItem.ToString();
            }
        }
        private void cmb_Error_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParamErrName = cmb_Error.SelectedItem.ToString();
        }

    }
}
