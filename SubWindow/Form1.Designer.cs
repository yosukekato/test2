﻿namespace BTWrapper
{
    partial class Form1
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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            this.bt_decide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_rightvalue = new System.Windows.Forms.TextBox();
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(33, 23);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(365, 251);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView1.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_exp_Paint);
            this.plotView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plotView1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.plotView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
			this.PerformLayout();
            // 
			// txt_rightvalue
			// 
			this.txt_rightvalue.Location = new System.Drawing.Point(101, 6);
			this.txt_rightvalue.Name = "txt_rightvalue";
			this.txt_rightvalue.Size = new System.Drawing.Size(100, 19);
			this.txt_rightvalue.TabIndex = 3;
			this.txt_rightvalue.TextChanged += new System.EventHandler(this.txt_rightvalue_TextChanged);
			//
			// bt_decide
			// 
			this.bt_decide.Location = new System.Drawing.Point(193, 288);
			this.bt_decide.Name = "bt_decide";
			this.bt_decide.Size = new System.Drawing.Size(172, 23);
			this.bt_decide.TabIndex = 1;
			this.bt_decide.Text = "Decide";
			this.bt_decide.UseVisualStyleBackColor = true;
			this.bt_decide.Click += new System.EventHandler(this.bt_decide_Click);
			//
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "RightMaxValue";
			// 
			this.Controls.Add(this.bt_decide);
            this.Controls.Add(this.txt_rightvalue);
            this.Controls.Add(this.label1);
            this.SizeChanged += new System.EventHandler(this.BackGroundWindow_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
		private System.Windows.Forms.Button bt_decide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_rightvalue;
    }
}

