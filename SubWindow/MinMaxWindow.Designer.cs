namespace BTWrapper
{
    partial class MinMaxWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_min = new System.Windows.Forms.Label();
            this.txt_min = new System.Windows.Forms.TextBox();
            this.txt_max = new System.Windows.Forms.TextBox();
            this.lbl_max = new System.Windows.Forms.Label();
            this.bt_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_min
            // 
            this.lbl_min.AutoSize = true;
            this.lbl_min.Location = new System.Drawing.Point(13, 13);
            this.lbl_min.Name = "lbl_min";
            this.lbl_min.Size = new System.Drawing.Size(23, 12);
            this.lbl_min.TabIndex = 0;
            this.lbl_min.Text = "min";
            // 
            // txt_min
            // 
            this.txt_min.Location = new System.Drawing.Point(54, 10);
            this.txt_min.Name = "txt_min";
            this.txt_min.Size = new System.Drawing.Size(100, 19);
            this.txt_min.TabIndex = 1;
            // 
            // txt_max
            // 
            this.txt_max.Location = new System.Drawing.Point(54, 35);
            this.txt_max.Name = "txt_max";
            this.txt_max.Size = new System.Drawing.Size(100, 19);
            this.txt_max.TabIndex = 3;
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Location = new System.Drawing.Point(13, 38);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(26, 12);
            this.lbl_max.TabIndex = 2;
            this.lbl_max.Text = "max";
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(43, 70);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 4;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // MinMaxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 105);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.txt_max);
            this.Controls.Add(this.lbl_max);
            this.Controls.Add(this.txt_min);
            this.Controls.Add(this.lbl_min);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinMaxWindow";
            this.Text = "MinMaxWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_min;
        private System.Windows.Forms.TextBox txt_min;
        private System.Windows.Forms.TextBox txt_max;
        private System.Windows.Forms.Label lbl_max;
        private System.Windows.Forms.Button bt_OK;
    }
}