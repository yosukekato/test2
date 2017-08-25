namespace BTWrapper
{
    partial class BTMainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCont = new System.Windows.Forms.TabControl();
            this.tabFEFF = new System.Windows.Forms.TabPage();
            this.txt_workdir = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_smooth = new System.Windows.Forms.Button();
            this.bt_chimod = new System.Windows.Forms.Button();
            this.bt_feff = new System.Windows.Forms.Button();
            this.txt_feff_smooth = new System.Windows.Forms.TextBox();
            this.bt_feff_smoothsel = new System.Windows.Forms.Button();
            this.bt_feff_smooth = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_runfeff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_TargetEdge = new System.Windows.Forms.ComboBox();
            this.bt_feffinp_select = new System.Windows.Forms.Button();
            this.txt_feffinp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_errcom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_expdatapath = new System.Windows.Forms.CheckBox();
            this.txt_workdir2 = new System.Windows.Forms.TextBox();
            this.bt_changedir2 = new System.Windows.Forms.Button();
            this.txt_moddata = new System.Windows.Forms.TextBox();
            this.bt_moddataselect = new System.Windows.Forms.Button();
            this.chk_moddata = new System.Windows.Forms.CheckBox();
            this.bt_runexp = new System.Windows.Forms.Button();
            this.txt_exp_smooth = new System.Windows.Forms.TextBox();
            this.bt_exp_smoothsel = new System.Windows.Forms.Button();
            this.bt_exp_smooth = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_error = new System.Windows.Forms.TextBox();
            this.bt_runerror = new System.Windows.Forms.Button();
            this.chk_error = new System.Windows.Forms.CheckBox();
            this.bt_selectpreedge = new System.Windows.Forms.Button();
            this.bt_subpreedge = new System.Windows.Forms.Button();
            this.chk_subs = new System.Windows.Forms.CheckBox();
            this.bt_exp_select = new System.Windows.Forms.Button();
            this.txt_exp = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_workdir3 = new System.Windows.Forms.TextBox();
            this.bt_changedir3 = new System.Windows.Forms.Button();
            this.bt_BTMain = new System.Windows.Forms.Button();
            this.txt_btinp = new System.Windows.Forms.TextBox();
            this.bt_btinpsel = new System.Windows.Forms.Button();
            this.bt_btinp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_rdf = new System.Windows.Forms.Button();
            this.bt_initchart = new System.Windows.Forms.Button();
            this.bt_sn2 = new System.Windows.Forms.Button();
            this.bt_resultchart = new System.Windows.Forms.Button();
            this.bt_others = new System.Windows.Forms.Button();
            this.bt_matrix = new System.Windows.Forms.Button();
            this.txt_workdir4 = new System.Windows.Forms.TextBox();
            this.bt_workdir4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFeffSmoothGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCont.SuspendLayout();
            this.tabFEFF.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCont
            // 
            this.tabCont.Controls.Add(this.tabFEFF);
            this.tabCont.Controls.Add(this.tabPage1);
            this.tabCont.Controls.Add(this.tabPage2);
            this.tabCont.Controls.Add(this.tabPage3);
            this.tabCont.Location = new System.Drawing.Point(12, 29);
            this.tabCont.Name = "tabCont";
            this.tabCont.SelectedIndex = 0;
            this.tabCont.Size = new System.Drawing.Size(447, 403);
            this.tabCont.TabIndex = 0;
            // 
            // tabFEFF
            // 
            this.tabFEFF.Controls.Add(this.txt_workdir);
            this.tabFEFF.Controls.Add(this.groupBox1);
            this.tabFEFF.Controls.Add(this.txt_feff_smooth);
            this.tabFEFF.Controls.Add(this.bt_feff_smoothsel);
            this.tabFEFF.Controls.Add(this.bt_feff_smooth);
            this.tabFEFF.Controls.Add(this.label4);
            this.tabFEFF.Controls.Add(this.bt_runfeff);
            this.tabFEFF.Controls.Add(this.label2);
            this.tabFEFF.Controls.Add(this.cmb_TargetEdge);
            this.tabFEFF.Controls.Add(this.bt_feffinp_select);
            this.tabFEFF.Controls.Add(this.txt_feffinp);
            this.tabFEFF.Controls.Add(this.label1);
            this.tabFEFF.Controls.Add(this.button1);
            this.tabFEFF.Location = new System.Drawing.Point(4, 22);
            this.tabFEFF.Name = "tabFEFF";
            this.tabFEFF.Padding = new System.Windows.Forms.Padding(3);
            this.tabFEFF.Size = new System.Drawing.Size(439, 377);
            this.tabFEFF.TabIndex = 0;
            this.tabFEFF.Text = "feff";
            this.tabFEFF.UseVisualStyleBackColor = true;
            // 
            // txt_workdir
            // 
            this.txt_workdir.Location = new System.Drawing.Point(157, 21);
            this.txt_workdir.Name = "txt_workdir";
            this.txt_workdir.ReadOnly = true;
            this.txt_workdir.Size = new System.Drawing.Size(276, 19);
            this.txt_workdir.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_smooth);
            this.groupBox1.Controls.Add(this.bt_chimod);
            this.groupBox1.Controls.Add(this.bt_feff);
            this.groupBox1.Location = new System.Drawing.Point(256, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 124);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Each Operation";
            // 
            // bt_smooth
            // 
            this.bt_smooth.Location = new System.Drawing.Point(37, 76);
            this.bt_smooth.Name = "bt_smooth";
            this.bt_smooth.Size = new System.Drawing.Size(75, 23);
            this.bt_smooth.TabIndex = 2;
            this.bt_smooth.Text = "smooth";
            this.bt_smooth.UseVisualStyleBackColor = true;
            this.bt_smooth.Click += new System.EventHandler(this.bt_smooth_Click);
            // 
            // bt_chimod
            // 
            this.bt_chimod.Location = new System.Drawing.Point(37, 47);
            this.bt_chimod.Name = "bt_chimod";
            this.bt_chimod.Size = new System.Drawing.Size(75, 23);
            this.bt_chimod.TabIndex = 1;
            this.bt_chimod.Text = "chimod";
            this.bt_chimod.UseVisualStyleBackColor = true;
            this.bt_chimod.Click += new System.EventHandler(this.bt_chimod_Click);
            // 
            // bt_feff
            // 
            this.bt_feff.Location = new System.Drawing.Point(37, 18);
            this.bt_feff.Name = "bt_feff";
            this.bt_feff.Size = new System.Drawing.Size(75, 23);
            this.bt_feff.TabIndex = 0;
            this.bt_feff.Text = "Feff";
            this.bt_feff.UseVisualStyleBackColor = true;
            this.bt_feff.Click += new System.EventHandler(this.bt_feff_Click);
            // 
            // txt_feff_smooth
            // 
            this.txt_feff_smooth.Location = new System.Drawing.Point(71, 179);
            this.txt_feff_smooth.Name = "txt_feff_smooth";
            this.txt_feff_smooth.Size = new System.Drawing.Size(216, 19);
            this.txt_feff_smooth.TabIndex = 11;
            // 
            // bt_feff_smoothsel
            // 
            this.bt_feff_smoothsel.Location = new System.Drawing.Point(358, 177);
            this.bt_feff_smoothsel.Name = "bt_feff_smoothsel";
            this.bt_feff_smoothsel.Size = new System.Drawing.Size(58, 23);
            this.bt_feff_smoothsel.TabIndex = 10;
            this.bt_feff_smoothsel.Text = "Select";
            this.bt_feff_smoothsel.UseVisualStyleBackColor = true;
            this.bt_feff_smoothsel.Click += new System.EventHandler(this.bt_feff_smoothsel_Click);
            // 
            // bt_feff_smooth
            // 
            this.bt_feff_smooth.Location = new System.Drawing.Point(293, 177);
            this.bt_feff_smooth.Name = "bt_feff_smooth";
            this.bt_feff_smooth.Size = new System.Drawing.Size(59, 23);
            this.bt_feff_smooth.TabIndex = 9;
            this.bt_feff_smooth.Text = "Create";
            this.bt_feff_smooth.UseVisualStyleBackColor = true;
            this.bt_feff_smooth.Click += new System.EventHandler(this.bt_feff_smooth_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "smooth.inp";
            // 
            // bt_runfeff
            // 
            this.bt_runfeff.Location = new System.Drawing.Point(8, 232);
            this.bt_runfeff.Name = "bt_runfeff";
            this.bt_runfeff.Size = new System.Drawing.Size(220, 23);
            this.bt_runfeff.TabIndex = 7;
            this.bt_runfeff.Text = "Run feff preparation";
            this.bt_runfeff.UseVisualStyleBackColor = true;
            this.bt_runfeff.Click += new System.EventHandler(this.bt_runfeff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Edge";
            // 
            // cmb_TargetEdge
            // 
            this.cmb_TargetEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TargetEdge.FormattingEnabled = true;
            this.cmb_TargetEdge.Items.AddRange(new object[] {
            "K Edge",
            "L Edge"});
            this.cmb_TargetEdge.Location = new System.Drawing.Point(78, 128);
            this.cmb_TargetEdge.Name = "cmb_TargetEdge";
            this.cmb_TargetEdge.Size = new System.Drawing.Size(121, 20);
            this.cmb_TargetEdge.TabIndex = 4;
            // 
            // bt_feffinp_select
            // 
            this.bt_feffinp_select.Location = new System.Drawing.Point(324, 76);
            this.bt_feffinp_select.Name = "bt_feffinp_select";
            this.bt_feffinp_select.Size = new System.Drawing.Size(75, 23);
            this.bt_feffinp_select.TabIndex = 3;
            this.bt_feffinp_select.Text = "Select";
            this.bt_feffinp_select.UseVisualStyleBackColor = true;
            this.bt_feffinp_select.Click += new System.EventHandler(this.bt_feffinp_select_Click);
            // 
            // txt_feffinp
            // 
            this.txt_feffinp.Location = new System.Drawing.Point(78, 76);
            this.txt_feffinp.Name = "txt_feffinp";
            this.txt_feffinp.Size = new System.Drawing.Size(239, 19);
            this.txt_feffinp.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "feff.inp path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Change Work Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bt_ChangeCurrentDirectory);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_errcom);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chk_expdatapath);
            this.tabPage1.Controls.Add(this.txt_workdir2);
            this.tabPage1.Controls.Add(this.bt_changedir2);
            this.tabPage1.Controls.Add(this.txt_moddata);
            this.tabPage1.Controls.Add(this.bt_moddataselect);
            this.tabPage1.Controls.Add(this.chk_moddata);
            this.tabPage1.Controls.Add(this.bt_runexp);
            this.tabPage1.Controls.Add(this.txt_exp_smooth);
            this.tabPage1.Controls.Add(this.bt_exp_smoothsel);
            this.tabPage1.Controls.Add(this.bt_exp_smooth);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_error);
            this.tabPage1.Controls.Add(this.bt_runerror);
            this.tabPage1.Controls.Add(this.chk_error);
            this.tabPage1.Controls.Add(this.bt_selectpreedge);
            this.tabPage1.Controls.Add(this.bt_subpreedge);
            this.tabPage1.Controls.Add(this.chk_subs);
            this.tabPage1.Controls.Add(this.bt_exp_select);
            this.tabPage1.Controls.Add(this.txt_exp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 377);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "exp data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_errcom
            // 
            this.txt_errcom.Location = new System.Drawing.Point(156, 177);
            this.txt_errcom.Name = "txt_errcom";
            this.txt_errcom.Size = new System.Drawing.Size(183, 19);
            this.txt_errcom.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "comment";
            // 
            // chk_expdatapath
            // 
            this.chk_expdatapath.AutoCheck = false;
            this.chk_expdatapath.AutoSize = true;
            this.chk_expdatapath.Location = new System.Drawing.Point(12, 85);
            this.chk_expdatapath.Name = "chk_expdatapath";
            this.chk_expdatapath.Size = new System.Drawing.Size(132, 16);
            this.chk_expdatapath.TabIndex = 23;
            this.chk_expdatapath.Text = "experiment data path";
            this.chk_expdatapath.UseVisualStyleBackColor = true;
            // 
            // txt_workdir2
            // 
            this.txt_workdir2.Location = new System.Drawing.Point(157, 21);
            this.txt_workdir2.Name = "txt_workdir2";
            this.txt_workdir2.ReadOnly = true;
            this.txt_workdir2.Size = new System.Drawing.Size(276, 19);
            this.txt_workdir2.TabIndex = 22;
            // 
            // bt_changedir2
            // 
            this.bt_changedir2.Location = new System.Drawing.Point(8, 19);
            this.bt_changedir2.Name = "bt_changedir2";
            this.bt_changedir2.Size = new System.Drawing.Size(143, 23);
            this.bt_changedir2.TabIndex = 21;
            this.bt_changedir2.Text = "Change Work Directory";
            this.bt_changedir2.UseVisualStyleBackColor = true;
            this.bt_changedir2.Click += new System.EventHandler(this.bt_ChangeCurrentDirectory);
            // 
            // txt_moddata
            // 
            this.txt_moddata.Location = new System.Drawing.Point(156, 211);
            this.txt_moddata.Name = "txt_moddata";
            this.txt_moddata.Size = new System.Drawing.Size(183, 19);
            this.txt_moddata.TabIndex = 20;
            // 
            // bt_moddataselect
            // 
            this.bt_moddataselect.Location = new System.Drawing.Point(345, 209);
            this.bt_moddataselect.Name = "bt_moddataselect";
            this.bt_moddataselect.Size = new System.Drawing.Size(75, 23);
            this.bt_moddataselect.TabIndex = 19;
            this.bt_moddataselect.Text = "Select";
            this.bt_moddataselect.UseVisualStyleBackColor = true;
            this.bt_moddataselect.Click += new System.EventHandler(this.bt_moddataselect_Click);
            // 
            // chk_moddata
            // 
            this.chk_moddata.AutoCheck = false;
            this.chk_moddata.AutoSize = true;
            this.chk_moddata.Location = new System.Drawing.Point(12, 213);
            this.chk_moddata.Name = "chk_moddata";
            this.chk_moddata.Size = new System.Drawing.Size(93, 16);
            this.chk_moddata.TabIndex = 18;
            this.chk_moddata.Text = "modified data";
            this.chk_moddata.UseVisualStyleBackColor = true;
            // 
            // bt_runexp
            // 
            this.bt_runexp.Location = new System.Drawing.Point(9, 302);
            this.bt_runexp.Name = "bt_runexp";
            this.bt_runexp.Size = new System.Drawing.Size(220, 23);
            this.bt_runexp.TabIndex = 17;
            this.bt_runexp.Text = "Run experiment file preparation";
            this.bt_runexp.UseVisualStyleBackColor = true;
            this.bt_runexp.Click += new System.EventHandler(this.bt_runexp_Click);
            // 
            // txt_exp_smooth
            // 
            this.txt_exp_smooth.Location = new System.Drawing.Point(75, 245);
            this.txt_exp_smooth.Name = "txt_exp_smooth";
            this.txt_exp_smooth.Size = new System.Drawing.Size(216, 19);
            this.txt_exp_smooth.TabIndex = 16;
            // 
            // bt_exp_smoothsel
            // 
            this.bt_exp_smoothsel.Location = new System.Drawing.Point(362, 243);
            this.bt_exp_smoothsel.Name = "bt_exp_smoothsel";
            this.bt_exp_smoothsel.Size = new System.Drawing.Size(58, 23);
            this.bt_exp_smoothsel.TabIndex = 15;
            this.bt_exp_smoothsel.Text = "Select";
            this.bt_exp_smoothsel.UseVisualStyleBackColor = true;
            this.bt_exp_smoothsel.Click += new System.EventHandler(this.bt_exp_smooth_Click);
            // 
            // bt_exp_smooth
            // 
            this.bt_exp_smooth.Location = new System.Drawing.Point(297, 243);
            this.bt_exp_smooth.Name = "bt_exp_smooth";
            this.bt_exp_smooth.Size = new System.Drawing.Size(59, 23);
            this.bt_exp_smooth.TabIndex = 14;
            this.bt_exp_smooth.Text = "Create";
            this.bt_exp_smooth.UseVisualStyleBackColor = true;
            this.bt_exp_smooth.Click += new System.EventHandler(this.bt_exp_smooth_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "smooth.inp";
            // 
            // txt_error
            // 
            this.txt_error.Location = new System.Drawing.Point(156, 157);
            this.txt_error.Name = "txt_error";
            this.txt_error.Size = new System.Drawing.Size(100, 19);
            this.txt_error.TabIndex = 12;
            // 
            // bt_runerror
            // 
            this.bt_runerror.Location = new System.Drawing.Point(345, 175);
            this.bt_runerror.Name = "bt_runerror";
            this.bt_runerror.Size = new System.Drawing.Size(75, 23);
            this.bt_runerror.TabIndex = 11;
            this.bt_runerror.Text = "Run";
            this.bt_runerror.UseVisualStyleBackColor = true;
            this.bt_runerror.Click += new System.EventHandler(this.bt_runerror_Click);
            // 
            // chk_error
            // 
            this.chk_error.AutoCheck = false;
            this.chk_error.AutoSize = true;
            this.chk_error.Location = new System.Drawing.Point(12, 159);
            this.chk_error.Name = "chk_error";
            this.chk_error.Size = new System.Drawing.Size(48, 16);
            this.chk_error.TabIndex = 10;
            this.chk_error.Text = "error";
            this.chk_error.UseVisualStyleBackColor = true;
            // 
            // bt_selectpreedge
            // 
            this.bt_selectpreedge.Location = new System.Drawing.Point(237, 117);
            this.bt_selectpreedge.Name = "bt_selectpreedge";
            this.bt_selectpreedge.Size = new System.Drawing.Size(75, 23);
            this.bt_selectpreedge.TabIndex = 9;
            this.bt_selectpreedge.Text = "Select";
            this.bt_selectpreedge.UseVisualStyleBackColor = true;
            this.bt_selectpreedge.Click += new System.EventHandler(this.bt_selectpreedge_Click);
            // 
            // bt_subpreedge
            // 
            this.bt_subpreedge.Location = new System.Drawing.Point(156, 117);
            this.bt_subpreedge.Name = "bt_subpreedge";
            this.bt_subpreedge.Size = new System.Drawing.Size(75, 23);
            this.bt_subpreedge.TabIndex = 8;
            this.bt_subpreedge.Text = "Run";
            this.bt_subpreedge.UseVisualStyleBackColor = true;
            this.bt_subpreedge.Click += new System.EventHandler(this.bt_subpreedge_Click);
            // 
            // chk_subs
            // 
            this.chk_subs.AutoCheck = false;
            this.chk_subs.AutoSize = true;
            this.chk_subs.Location = new System.Drawing.Point(12, 121);
            this.chk_subs.Name = "chk_subs";
            this.chk_subs.Size = new System.Drawing.Size(138, 16);
            this.chk_subs.TabIndex = 7;
            this.chk_subs.Text = "subtract pre-edge line";
            this.chk_subs.UseVisualStyleBackColor = true;
            // 
            // bt_exp_select
            // 
            this.bt_exp_select.Location = new System.Drawing.Point(357, 79);
            this.bt_exp_select.Name = "bt_exp_select";
            this.bt_exp_select.Size = new System.Drawing.Size(75, 23);
            this.bt_exp_select.TabIndex = 6;
            this.bt_exp_select.Text = "Select";
            this.bt_exp_select.UseVisualStyleBackColor = true;
            this.bt_exp_select.Click += new System.EventHandler(this.bt_exp_select_Click);
            // 
            // txt_exp
            // 
            this.txt_exp.Location = new System.Drawing.Point(156, 81);
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(195, 19);
            this.txt_exp.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_workdir3);
            this.tabPage2.Controls.Add(this.bt_changedir3);
            this.tabPage2.Controls.Add(this.bt_BTMain);
            this.tabPage2.Controls.Add(this.txt_btinp);
            this.tabPage2.Controls.Add(this.bt_btinpsel);
            this.tabPage2.Controls.Add(this.bt_btinp);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 377);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "BTMain";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_workdir3
            // 
            this.txt_workdir3.Location = new System.Drawing.Point(157, 21);
            this.txt_workdir3.Name = "txt_workdir3";
            this.txt_workdir3.ReadOnly = true;
            this.txt_workdir3.Size = new System.Drawing.Size(276, 19);
            this.txt_workdir3.TabIndex = 24;
            // 
            // bt_changedir3
            // 
            this.bt_changedir3.Location = new System.Drawing.Point(8, 19);
            this.bt_changedir3.Name = "bt_changedir3";
            this.bt_changedir3.Size = new System.Drawing.Size(143, 23);
            this.bt_changedir3.TabIndex = 23;
            this.bt_changedir3.Text = "Change Work Directory";
            this.bt_changedir3.UseVisualStyleBackColor = true;
            this.bt_changedir3.Click += new System.EventHandler(this.bt_ChangeCurrentDirectory);
            // 
            // bt_BTMain
            // 
            this.bt_BTMain.Location = new System.Drawing.Point(11, 99);
            this.bt_BTMain.Name = "bt_BTMain";
            this.bt_BTMain.Size = new System.Drawing.Size(187, 23);
            this.bt_BTMain.TabIndex = 16;
            this.bt_BTMain.Text = "Run BT main program";
            this.bt_BTMain.UseVisualStyleBackColor = true;
            this.bt_BTMain.Click += new System.EventHandler(this.bt_BTMain_Click);
            // 
            // txt_btinp
            // 
            this.txt_btinp.Location = new System.Drawing.Point(74, 61);
            this.txt_btinp.Name = "txt_btinp";
            this.txt_btinp.Size = new System.Drawing.Size(216, 19);
            this.txt_btinp.TabIndex = 15;
            // 
            // bt_btinpsel
            // 
            this.bt_btinpsel.Location = new System.Drawing.Point(361, 59);
            this.bt_btinpsel.Name = "bt_btinpsel";
            this.bt_btinpsel.Size = new System.Drawing.Size(58, 23);
            this.bt_btinpsel.TabIndex = 14;
            this.bt_btinpsel.Text = "Select";
            this.bt_btinpsel.UseVisualStyleBackColor = true;
            this.bt_btinpsel.Click += new System.EventHandler(this.bt_btinpsel_Click);
            // 
            // bt_btinp
            // 
            this.bt_btinp.Location = new System.Drawing.Point(296, 59);
            this.bt_btinp.Name = "bt_btinp";
            this.bt_btinp.Size = new System.Drawing.Size(59, 23);
            this.bt_btinp.TabIndex = 13;
            this.bt_btinp.Text = "Create";
            this.bt_btinp.UseVisualStyleBackColor = true;
            this.bt_btinp.Click += new System.EventHandler(this.bt_btinp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "BTinp.dat";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.txt_workdir4);
            this.tabPage3.Controls.Add(this.bt_workdir4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(439, 377);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Data Analysis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_rdf);
            this.groupBox2.Controls.Add(this.bt_initchart);
            this.groupBox2.Controls.Add(this.bt_sn2);
            this.groupBox2.Controls.Add(this.bt_resultchart);
            this.groupBox2.Controls.Add(this.bt_others);
            this.groupBox2.Controls.Add(this.bt_matrix);
            this.groupBox2.Location = new System.Drawing.Point(8, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 146);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Graphs";
            // 
            // bt_rdf
            // 
            this.bt_rdf.Location = new System.Drawing.Point(177, 18);
            this.bt_rdf.Name = "bt_rdf";
            this.bt_rdf.Size = new System.Drawing.Size(79, 23);
            this.bt_rdf.TabIndex = 29;
            this.bt_rdf.Text = "RDF";
            this.bt_rdf.UseVisualStyleBackColor = true;
            this.bt_rdf.Click += new System.EventHandler(this.bt_rdf_Click);
            // 
            // bt_initchart
            // 
            this.bt_initchart.Location = new System.Drawing.Point(7, 18);
            this.bt_initchart.Name = "bt_initchart";
            this.bt_initchart.Size = new System.Drawing.Size(79, 23);
            this.bt_initchart.TabIndex = 2;
            this.bt_initchart.Text = "Initial State";
            this.bt_initchart.UseVisualStyleBackColor = true;
            this.bt_initchart.Click += new System.EventHandler(this.bt_initchart_Click);
            // 
            // bt_sn2
            // 
            this.bt_sn2.Location = new System.Drawing.Point(112, 57);
            this.bt_sn2.Name = "bt_sn2";
            this.bt_sn2.Size = new System.Drawing.Size(99, 23);
            this.bt_sn2.TabIndex = 31;
            this.bt_sn2.Text = "Sn2";
            this.bt_sn2.UseVisualStyleBackColor = true;
            this.bt_sn2.Click += new System.EventHandler(this.bt_sn2_Click);
            // 
            // bt_resultchart
            // 
            this.bt_resultchart.Location = new System.Drawing.Point(92, 18);
            this.bt_resultchart.Name = "bt_resultchart";
            this.bt_resultchart.Size = new System.Drawing.Size(79, 23);
            this.bt_resultchart.TabIndex = 3;
            this.bt_resultchart.Text = "Final State";
            this.bt_resultchart.UseVisualStyleBackColor = true;
            this.bt_resultchart.Click += new System.EventHandler(this.bt_resultchart_Click);
            // 
            // bt_others
            // 
            this.bt_others.Location = new System.Drawing.Point(262, 18);
            this.bt_others.Name = "bt_others";
            this.bt_others.Size = new System.Drawing.Size(99, 23);
            this.bt_others.TabIndex = 28;
            this.bt_others.Text = "Other Data";
            this.bt_others.UseVisualStyleBackColor = true;
            this.bt_others.Click += new System.EventHandler(this.bt_others_Click);
            // 
            // bt_matrix
            // 
            this.bt_matrix.Location = new System.Drawing.Point(7, 57);
            this.bt_matrix.Name = "bt_matrix";
            this.bt_matrix.Size = new System.Drawing.Size(99, 23);
            this.bt_matrix.TabIndex = 29;
            this.bt_matrix.Text = "Matrix";
            this.bt_matrix.UseVisualStyleBackColor = true;
            this.bt_matrix.Click += new System.EventHandler(this.bt_matrix_Click);
            // 
            // txt_workdir4
            // 
            this.txt_workdir4.Location = new System.Drawing.Point(157, 21);
            this.txt_workdir4.Name = "txt_workdir4";
            this.txt_workdir4.ReadOnly = true;
            this.txt_workdir4.Size = new System.Drawing.Size(276, 19);
            this.txt_workdir4.TabIndex = 26;
            // 
            // bt_workdir4
            // 
            this.bt_workdir4.Location = new System.Drawing.Point(8, 19);
            this.bt_workdir4.Name = "bt_workdir4";
            this.bt_workdir4.Size = new System.Drawing.Size(143, 23);
            this.bt_workdir4.TabIndex = 25;
            this.bt_workdir4.Text = "Change Work Directory";
            this.bt_workdir4.UseVisualStyleBackColor = true;
            this.bt_workdir4.Click += new System.EventHandler(this.bt_ChangeCurrentDirectory);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(471, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workDirectoryToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.showFeffSmoothGraphToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // workDirectoryToolStripMenuItem
            // 
            this.workDirectoryToolStripMenuItem.Name = "workDirectoryToolStripMenuItem";
            this.workDirectoryToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.workDirectoryToolStripMenuItem.Text = "Change WorkDirectory";
            this.workDirectoryToolStripMenuItem.Click += new System.EventHandler(this.bt_ChangeCurrentDirectory);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // japaneseToolStripMenuItem
            // 
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.japaneseToolStripMenuItem.Text = "Japanese";
            // 
            // showFeffSmoothGraphToolStripMenuItem
            // 
            this.showFeffSmoothGraphToolStripMenuItem.CheckOnClick = true;
            this.showFeffSmoothGraphToolStripMenuItem.Name = "showFeffSmoothGraphToolStripMenuItem";
            this.showFeffSmoothGraphToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.showFeffSmoothGraphToolStripMenuItem.Text = "Show Feff/Smooth Graph";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BTMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 444);
            this.Controls.Add(this.tabCont);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BTMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BT";
            this.tabCont.ResumeLayout(false);
            this.tabFEFF.ResumeLayout(false);
            this.tabFEFF.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCont;
        private System.Windows.Forms.TabPage tabFEFF;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button bt_runfeff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_TargetEdge;
        private System.Windows.Forms.Button bt_feffinp_select;
        private System.Windows.Forms.TextBox txt_feffinp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_exp_select;
        private System.Windows.Forms.TextBox txt_exp;
        private System.Windows.Forms.TextBox txt_feff_smooth;
        private System.Windows.Forms.Button bt_feff_smoothsel;
        private System.Windows.Forms.Button bt_feff_smooth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_runerror;
        private System.Windows.Forms.CheckBox chk_error;
        private System.Windows.Forms.Button bt_selectpreedge;
        private System.Windows.Forms.Button bt_subpreedge;
        private System.Windows.Forms.CheckBox chk_subs;
        private System.Windows.Forms.Button bt_runexp;
        private System.Windows.Forms.TextBox txt_exp_smooth;
        private System.Windows.Forms.Button bt_exp_smoothsel;
        private System.Windows.Forms.Button bt_exp_smooth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_error;
        private System.Windows.Forms.Button bt_BTMain;
        private System.Windows.Forms.TextBox txt_btinp;
        private System.Windows.Forms.Button bt_btinpsel;
        private System.Windows.Forms.Button bt_btinp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_smooth;
        private System.Windows.Forms.Button bt_chimod;
        private System.Windows.Forms.Button bt_feff;
        private System.Windows.Forms.TextBox txt_moddata;
        private System.Windows.Forms.Button bt_moddataselect;
        private System.Windows.Forms.CheckBox chk_moddata;
        private System.Windows.Forms.TextBox txt_workdir;
        private System.Windows.Forms.TextBox txt_workdir2;
        private System.Windows.Forms.Button bt_changedir2;
        private System.Windows.Forms.TextBox txt_workdir3;
        private System.Windows.Forms.Button bt_changedir3;
        private System.Windows.Forms.Button bt_sn2;
        private System.Windows.Forms.Button bt_matrix;
        private System.Windows.Forms.Button bt_others;
        private System.Windows.Forms.TextBox txt_workdir4;
        private System.Windows.Forms.Button bt_workdir4;
        private System.Windows.Forms.Button bt_resultchart;
        private System.Windows.Forms.Button bt_initchart;
        private System.Windows.Forms.CheckBox chk_expdatapath;
        private System.Windows.Forms.TextBox txt_errcom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_rdf;
        private System.Windows.Forms.ToolStripMenuItem showFeffSmoothGraphToolStripMenuItem;
    }
}

