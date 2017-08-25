namespace BTWrapper
{
    partial class GraphShowWindow
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
            //System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            //System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            //System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            //this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart = new OxyPlot.WindowsForms.PlotView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            //chartArea1.AxisX.MajorGrid.Enabled = false;
            //chartArea1.AxisY.MajorGrid.Enabled = false;
            //chartArea1.Name = "ChartArea1";
            //this.chart.ChartAreas.Add(chartArea1);
            //legend1.Name = "Exp";
            //this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(-1, 26);
            this.chart.Name = "chart";
            //series1.ChartArea = "ChartArea1";
            //series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //series1.Legend = "Exp";
            //series1.Name = "Exp";
            //this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(462, 300);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_Paint);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem,
            this.rangeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGraphToolStripMenuItem1,
            this.saveGraphToTextToolStripMenuItem,
            this.addGraphToolStripMenuItem,
            this.deleteGraphToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.OptionToolStripMenuItem.Text = "Option";
            // 
            // saveGraphToolStripMenuItem1
            // 
            this.saveGraphToolStripMenuItem1.Name = "saveGraphToolStripMenuItem1";
            this.saveGraphToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.saveGraphToolStripMenuItem1.Text = "Save Graph";
            this.saveGraphToolStripMenuItem1.Click += new System.EventHandler(this.saveGraphToolStripMenuItem1_Click);
            // 
            // saveGraphToTextToolStripMenuItem
            // 
            this.saveGraphToTextToolStripMenuItem.Name = "saveGraphToTextToolStripMenuItem";
            this.saveGraphToTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveGraphToTextToolStripMenuItem.Text = "Save Graph to Text";
            this.saveGraphToTextToolStripMenuItem.Click += new System.EventHandler(this.saveGraphToTextToolStripMenuItem_Click);
            // 
            // addGraphToolStripMenuItem
            // 
            this.addGraphToolStripMenuItem.Name = "addGraphToolStripMenuItem";
            this.addGraphToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addGraphToolStripMenuItem.Text = "Add Graph";
            this.addGraphToolStripMenuItem.Click += new System.EventHandler(this.addGraphToolStripMenuItem_Click);
            // 
            // deleteGraphToolStripMenuItem
            // 
            this.deleteGraphToolStripMenuItem.Name = "deleteGraphToolStripMenuItem";
            this.deleteGraphToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteGraphToolStripMenuItem.Text = "Delete Graph";
            this.deleteGraphToolStripMenuItem.Click += new System.EventHandler(this.deleteGraphToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // rangeToolStripMenuItem
            // 
            this.rangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.defaultToolStripMenuItem,
            this.autoYToolStripMenuItem});
            this.rangeToolStripMenuItem.Name = "rangeToolStripMenuItem";
            this.rangeToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.rangeToolStripMenuItem.Text = "Range";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.XYToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.XYToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // autoYToolStripMenuItem
            // 
            this.autoYToolStripMenuItem.Checked = true;
            this.autoYToolStripMenuItem.CheckOnClick = true;
            this.autoYToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoYToolStripMenuItem.Name = "autoYToolStripMenuItem";
            this.autoYToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.autoYToolStripMenuItem.Text = "Auto Y Range";
            // 
            // GraphShowWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 447);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphShowWindow";
            this.Text = "GraphShowWindow";
            this.SizeChanged += new System.EventHandler(this.GraphShowWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //protected System.Windows.Forms.DataVisualization.Charting.Chart chart;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem1;
        protected System.Windows.Forms.ToolStripMenuItem saveGraphToTextToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem addGraphToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem rangeToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem autoYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGraphToolStripMenuItem;
    }
}