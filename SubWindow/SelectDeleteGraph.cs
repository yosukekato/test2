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
    public partial class SelectDeleteGraph : Form
    {
        public SelectDeleteGraph(List<string> paramname)
        {
            InitializeComponent();
            foreach (var s in paramname)
            {
                comboBox1.Items.Add(s);
            }
        }
        public string SelectedIndexText = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SelectedIndexText = comboBox1.SelectedItem.ToString();
            Close();
        }
    }
}
