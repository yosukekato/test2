using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BTWrapper
{
    public partial class LogWindow : Form
    {
        public LogWindow(Point p)
        {
            InitializeComponent();
            this.ClientSize = new Size(400, 400);
            txt_log.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 25); ;
            bt_clear.Location = new Point(0, this.ClientSize.Height - 25);
            bt_clear.Size = new Size(this.ClientSize.Width / 3, 25);
            bt_append.Location = new Point(this.ClientSize.Width / 3, this.ClientSize.Height - 25);
            bt_append.Size = new Size(this.ClientSize.Width / 3, 25);
            bt_logout.Location = new Point(this.ClientSize.Width * 2 / 3, this.ClientSize.Height - 25);
            bt_logout.Size = new Size(this.ClientSize.Width / 3, 25);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = p;
            txt_log.HideSelection = false;

        }
        private void LogWindow_SizeChanged(object sender, EventArgs e)
        {
            txt_log.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 25);

            bt_clear.Location = new Point(0, this.ClientSize.Height - 25);
            bt_clear.Size = new Size(this.ClientSize.Width / 3, 25);
            bt_append.Location = new Point(this.ClientSize.Width  / 3, this.ClientSize.Height - 25);
            bt_append.Size = new Size(this.ClientSize.Width / 3, 25);
            bt_logout.Location = new Point(this.ClientSize.Width *2/ 3, this.ClientSize.Height - 25);
            bt_logout.Size = new Size(this.ClientSize.Width/3, 25);
        }
        public void Flush()
        {
            txt_log.Text = "";
        }
        public void Add(string s)
        {
            txt_log.Text += s;
            txt_log.SelectionStart = txt_log.Text.Length;
            txt_log.ScrollToCaret();
        }
        public void AddL(string s)
        {
            txt_log.AppendText(s + Environment.NewLine);
        }
        public void SaveException()
        {
            using (StreamWriter sw = new StreamWriter("log.txt", false, BTMainForm.CharEncode))
            {
                sw.Write(txt_log.Text);
            }
        }
        private void OutputLogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "log.txt";
            sfd.Filter = "txt file|*.txt|all file|*.*";
            sfd.Title = "save log file";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName,
                    ((Button)sender).Name == bt_append.Name , BTMainForm.CharEncode))
                {
                    sw.Write(txt_log.Text);
                }
            }
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            txt_log.Text = "";
        }
    }
}
