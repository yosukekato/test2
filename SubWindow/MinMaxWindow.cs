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
    public partial class MinMaxWindow : Form
    {
        double max;
        public double Max
        {
            get { return max; }
            set { max = value; }
        }
        double min;
        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public MinMaxWindow(string paramstr)
        {
            InitializeComponent();
            lbl_max.Text = paramstr + " " + lbl_max.Text;
            lbl_min.Text = paramstr + " " + lbl_min.Text;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            try
            {
                min = double.Parse(txt_min.Text);
                max = double.Parse(txt_max.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {

            }
            finally
            {
                Close();
            }
        }
    }
}
