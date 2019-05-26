namespace ScoreCalculator
{
    partial class ScoreCal_Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreCal_Form1));
            this.TJAReader = new System.Windows.Forms.Button();
            this.TJAName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Difficulty = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ndk0 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ntdk0 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gdk0 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gtdk0 = new System.Windows.Forms.Label();
            this.ndk1 = new System.Windows.Forms.Label();
            this.ntdk1 = new System.Windows.Forms.Label();
            this.gdk1 = new System.Windows.Forms.Label();
            this.gtdk1 = new System.Windows.Forms.Label();
            this.ndk2 = new System.Windows.Forms.Label();
            this.ntdk2 = new System.Windows.Forms.Label();
            this.gdk2 = new System.Windows.Forms.Label();
            this.gtdk2 = new System.Windows.Forms.Label();
            this.ndk3 = new System.Windows.Forms.Label();
            this.ntdk3 = new System.Windows.Forms.Label();
            this.gdk3 = new System.Windows.Forms.Label();
            this.gtdk3 = new System.Windows.Forms.Label();
            this.ndk4 = new System.Windows.Forms.Label();
            this.ntdk4 = new System.Windows.Forms.Label();
            this.gdk4 = new System.Windows.Forms.Label();
            this.gtdk4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SCOREINIT = new System.Windows.Forms.Label();
            this.SCOREDIFF = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.re = new System.Windows.Forms.Label();
            this.ScoreUD = new System.Windows.Forms.NumericUpDown();
            this.スコア基準 = new System.Windows.Forms.Label();
            this.Diff比率 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.basum0 = new System.Windows.Forms.Label();
            this.baamount0 = new System.Windows.Forms.Label();
            this.basum1 = new System.Windows.Forms.Label();
            this.baamount1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.INITM = new System.Windows.Forms.NumericUpDown();
            this.DIFFM = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diff比率)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.INITM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIFFM)).BeginInit();
            this.SuspendLayout();
            // 
            // TJAReader
            // 
            this.TJAReader.Font = new System.Drawing.Font("メイリオ", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TJAReader.Location = new System.Drawing.Point(9, 297);
            this.TJAReader.Margin = new System.Windows.Forms.Padding(2);
            this.TJAReader.Name = "TJAReader";
            this.TJAReader.Size = new System.Drawing.Size(582, 131);
            this.TJAReader.TabIndex = 0;
            this.TJAReader.Text = "TJAファイルを読み込む";
            this.TJAReader.UseVisualStyleBackColor = true;
            this.TJAReader.Click += new System.EventHandler(this.TJAReader_Click);
            // 
            // TJAName
            // 
            this.TJAName.AutoSize = true;
            this.TJAName.Location = new System.Drawing.Point(12, 7);
            this.TJAName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TJAName.Name = "TJAName";
            this.TJAName.Size = new System.Drawing.Size(166, 12);
            this.TJAName.TabIndex = 1;
            this.TJAName.Text = "TJAファイルを読み込んでください。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "総音符数=";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(73, 44);
            this.Total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(20, 12);
            this.Total.TabIndex = 3;
            this.Total.Text = "???";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(109, 44);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "★";
            // 
            // Difficulty
            // 
            this.Difficulty.AutoSize = true;
            this.Difficulty.Location = new System.Drawing.Point(128, 44);
            this.Difficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(10, 12);
            this.Difficulty.TabIndex = 17;
            this.Difficulty.Text = "?";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(629, 9);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(518, 406);
            this.textBox1.TabIndex = 18;
            // 
            // ndk0
            // 
            this.ndk0.AutoSize = true;
            this.ndk0.Location = new System.Drawing.Point(104, 85);
            this.ndk0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ndk0.Name = "ndk0";
            this.ndk0.Size = new System.Drawing.Size(20, 12);
            this.ndk0.TabIndex = 20;
            this.ndk0.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "通常小音符=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "通常大音符=";
            // 
            // ntdk0
            // 
            this.ntdk0.AutoSize = true;
            this.ntdk0.Location = new System.Drawing.Point(104, 106);
            this.ntdk0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ntdk0.Name = "ntdk0";
            this.ntdk0.Size = new System.Drawing.Size(20, 12);
            this.ntdk0.TabIndex = 23;
            this.ntdk0.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(20, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "ゴーゴー小音符=";
            // 
            // gdk0
            // 
            this.gdk0.AutoSize = true;
            this.gdk0.Location = new System.Drawing.Point(105, 126);
            this.gdk0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gdk0.Name = "gdk0";
            this.gdk0.Size = new System.Drawing.Size(20, 12);
            this.gdk0.TabIndex = 25;
            this.gdk0.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(19, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "ゴーゴー大音符=";
            // 
            // gtdk0
            // 
            this.gtdk0.AutoSize = true;
            this.gtdk0.Location = new System.Drawing.Point(104, 146);
            this.gtdk0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtdk0.Name = "gtdk0";
            this.gtdk0.Size = new System.Drawing.Size(20, 12);
            this.gtdk0.TabIndex = 27;
            this.gtdk0.Text = "???";
            // 
            // ndk1
            // 
            this.ndk1.AutoSize = true;
            this.ndk1.Location = new System.Drawing.Point(152, 85);
            this.ndk1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ndk1.Name = "ndk1";
            this.ndk1.Size = new System.Drawing.Size(20, 12);
            this.ndk1.TabIndex = 28;
            this.ndk1.Text = "???";
            // 
            // ntdk1
            // 
            this.ntdk1.AutoSize = true;
            this.ntdk1.Location = new System.Drawing.Point(152, 106);
            this.ntdk1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ntdk1.Name = "ntdk1";
            this.ntdk1.Size = new System.Drawing.Size(20, 12);
            this.ntdk1.TabIndex = 29;
            this.ntdk1.Text = "???";
            // 
            // gdk1
            // 
            this.gdk1.AutoSize = true;
            this.gdk1.Location = new System.Drawing.Point(152, 126);
            this.gdk1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gdk1.Name = "gdk1";
            this.gdk1.Size = new System.Drawing.Size(20, 12);
            this.gdk1.TabIndex = 30;
            this.gdk1.Text = "???";
            // 
            // gtdk1
            // 
            this.gtdk1.AutoSize = true;
            this.gtdk1.Location = new System.Drawing.Point(152, 146);
            this.gtdk1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtdk1.Name = "gtdk1";
            this.gtdk1.Size = new System.Drawing.Size(20, 12);
            this.gtdk1.TabIndex = 31;
            this.gtdk1.Text = "???";
            // 
            // ndk2
            // 
            this.ndk2.AutoSize = true;
            this.ndk2.Location = new System.Drawing.Point(200, 85);
            this.ndk2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ndk2.Name = "ndk2";
            this.ndk2.Size = new System.Drawing.Size(20, 12);
            this.ndk2.TabIndex = 32;
            this.ndk2.Text = "???";
            // 
            // ntdk2
            // 
            this.ntdk2.AutoSize = true;
            this.ntdk2.Location = new System.Drawing.Point(200, 106);
            this.ntdk2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ntdk2.Name = "ntdk2";
            this.ntdk2.Size = new System.Drawing.Size(20, 12);
            this.ntdk2.TabIndex = 33;
            this.ntdk2.Text = "???";
            // 
            // gdk2
            // 
            this.gdk2.AutoSize = true;
            this.gdk2.Location = new System.Drawing.Point(200, 126);
            this.gdk2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gdk2.Name = "gdk2";
            this.gdk2.Size = new System.Drawing.Size(20, 12);
            this.gdk2.TabIndex = 34;
            this.gdk2.Text = "???";
            // 
            // gtdk2
            // 
            this.gtdk2.AutoSize = true;
            this.gtdk2.Location = new System.Drawing.Point(200, 146);
            this.gtdk2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtdk2.Name = "gtdk2";
            this.gtdk2.Size = new System.Drawing.Size(20, 12);
            this.gtdk2.TabIndex = 35;
            this.gtdk2.Text = "???";
            // 
            // ndk3
            // 
            this.ndk3.AutoSize = true;
            this.ndk3.Location = new System.Drawing.Point(252, 85);
            this.ndk3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ndk3.Name = "ndk3";
            this.ndk3.Size = new System.Drawing.Size(20, 12);
            this.ndk3.TabIndex = 36;
            this.ndk3.Text = "???";
            // 
            // ntdk3
            // 
            this.ntdk3.AutoSize = true;
            this.ntdk3.Location = new System.Drawing.Point(252, 106);
            this.ntdk3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ntdk3.Name = "ntdk3";
            this.ntdk3.Size = new System.Drawing.Size(20, 12);
            this.ntdk3.TabIndex = 37;
            this.ntdk3.Text = "???";
            // 
            // gdk3
            // 
            this.gdk3.AutoSize = true;
            this.gdk3.Location = new System.Drawing.Point(252, 126);
            this.gdk3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gdk3.Name = "gdk3";
            this.gdk3.Size = new System.Drawing.Size(20, 12);
            this.gdk3.TabIndex = 38;
            this.gdk3.Text = "???";
            // 
            // gtdk3
            // 
            this.gtdk3.AutoSize = true;
            this.gtdk3.Location = new System.Drawing.Point(252, 146);
            this.gtdk3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtdk3.Name = "gtdk3";
            this.gtdk3.Size = new System.Drawing.Size(20, 12);
            this.gtdk3.TabIndex = 39;
            this.gtdk3.Text = "???";
            // 
            // ndk4
            // 
            this.ndk4.AutoSize = true;
            this.ndk4.Location = new System.Drawing.Point(302, 85);
            this.ndk4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ndk4.Name = "ndk4";
            this.ndk4.Size = new System.Drawing.Size(20, 12);
            this.ndk4.TabIndex = 40;
            this.ndk4.Text = "???";
            // 
            // ntdk4
            // 
            this.ntdk4.AutoSize = true;
            this.ntdk4.Location = new System.Drawing.Point(302, 106);
            this.ntdk4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ntdk4.Name = "ntdk4";
            this.ntdk4.Size = new System.Drawing.Size(20, 12);
            this.ntdk4.TabIndex = 41;
            this.ntdk4.Text = "???";
            // 
            // gdk4
            // 
            this.gdk4.AutoSize = true;
            this.gdk4.Location = new System.Drawing.Point(302, 126);
            this.gdk4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gdk4.Name = "gdk4";
            this.gdk4.Size = new System.Drawing.Size(20, 12);
            this.gdk4.TabIndex = 42;
            this.gdk4.Text = "???";
            // 
            // gtdk4
            // 
            this.gtdk4.AutoSize = true;
            this.gtdk4.Location = new System.Drawing.Point(302, 146);
            this.gtdk4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtdk4.Name = "gtdk4";
            this.gtdk4.Size = new System.Drawing.Size(20, 12);
            this.gtdk4.TabIndex = 43;
            this.gtdk4.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "0～9　　10～29 　 30～49  　50～99　  100～";
            // 
            // SCOREINIT
            // 
            this.SCOREINIT.AutoSize = true;
            this.SCOREINIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SCOREINIT.Location = new System.Drawing.Point(406, 59);
            this.SCOREINIT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SCOREINIT.Name = "SCOREINIT";
            this.SCOREINIT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SCOREINIT.Size = new System.Drawing.Size(115, 20);
            this.SCOREINIT.TabIndex = 45;
            this.SCOREINIT.Text = "SCOREINIT=";
            this.SCOREINIT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SCOREDIFF
            // 
            this.SCOREDIFF.AutoSize = true;
            this.SCOREDIFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SCOREDIFF.Location = new System.Drawing.Point(404, 84);
            this.SCOREDIFF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SCOREDIFF.Name = "SCOREDIFF";
            this.SCOREDIFF.Size = new System.Drawing.Size(122, 20);
            this.SCOREDIFF.TabIndex = 47;
            this.SCOREDIFF.Text = "SCOREDIFF=";
            this.SCOREDIFF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(428, 122);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 20);
            this.label13.TabIndex = 49;
            this.label13.Text = "天井点=";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // re
            // 
            this.re.AutoSize = true;
            this.re.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.re.Location = new System.Drawing.Point(498, 123);
            this.re.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.re.Name = "re";
            this.re.Size = new System.Drawing.Size(39, 20);
            this.re.TabIndex = 50;
            this.re.Text = "???";
            // 
            // ScoreUD
            // 
            this.ScoreUD.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ScoreUD.Location = new System.Drawing.Point(406, 180);
            this.ScoreUD.Margin = new System.Windows.Forms.Padding(2);
            this.ScoreUD.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.ScoreUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ScoreUD.Name = "ScoreUD";
            this.ScoreUD.Size = new System.Drawing.Size(133, 19);
            this.ScoreUD.TabIndex = 52;
            this.ScoreUD.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ScoreUD.ValueChanged += new System.EventHandler(this.ScoreUD_ValueChanged);
            // 
            // スコア基準
            // 
            this.スコア基準.AutoSize = true;
            this.スコア基準.Location = new System.Drawing.Point(350, 182);
            this.スコア基準.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.スコア基準.Name = "スコア基準";
            this.スコア基準.Size = new System.Drawing.Size(55, 12);
            this.スコア基準.TabIndex = 53;
            this.スコア基準.Text = "スコア基準";
            // 
            // Diff比率
            // 
            this.Diff比率.DecimalPlaces = 1;
            this.Diff比率.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Diff比率.Location = new System.Drawing.Point(406, 210);
            this.Diff比率.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Diff比率.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Diff比率.Name = "Diff比率";
            this.Diff比率.Size = new System.Drawing.Size(41, 19);
            this.Diff比率.TabIndex = 54;
            this.Diff比率.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Diff比率.ValueChanged += new System.EventHandler(this.Diff比率_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "DIFF比率";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1066, 416);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 12);
            this.linkLabel1.TabIndex = 56;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "@yume1610rein";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(908, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 12);
            this.label9.TabIndex = 57;
            this.label9.Text = "バグ、不具合報告はこちらに！→";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(20, 183);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 63;
            this.label15.Text = "通常風船個数=";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(20, 206);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 12);
            this.label18.TabIndex = 64;
            this.label18.Text = "通常風船打数=";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(20, 228);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 12);
            this.label19.TabIndex = 65;
            this.label19.Text = "ゴーゴー風船個数=";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(20, 246);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 12);
            this.label20.TabIndex = 66;
            this.label20.Text = "ゴーゴー風船打数=";
            // 
            // basum0
            // 
            this.basum0.AutoSize = true;
            this.basum0.Location = new System.Drawing.Point(119, 183);
            this.basum0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.basum0.Name = "basum0";
            this.basum0.Size = new System.Drawing.Size(20, 12);
            this.basum0.TabIndex = 67;
            this.basum0.Text = "???";
            // 
            // baamount0
            // 
            this.baamount0.AutoSize = true;
            this.baamount0.Location = new System.Drawing.Point(119, 206);
            this.baamount0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.baamount0.Name = "baamount0";
            this.baamount0.Size = new System.Drawing.Size(20, 12);
            this.baamount0.TabIndex = 68;
            this.baamount0.Text = "???";
            // 
            // basum1
            // 
            this.basum1.AutoSize = true;
            this.basum1.Location = new System.Drawing.Point(119, 228);
            this.basum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.basum1.Name = "basum1";
            this.basum1.Size = new System.Drawing.Size(20, 12);
            this.basum1.TabIndex = 69;
            this.basum1.Text = "???";
            // 
            // baamount1
            // 
            this.baamount1.AutoSize = true;
            this.baamount1.Location = new System.Drawing.Point(119, 246);
            this.baamount1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.baamount1.Name = "baamount1";
            this.baamount1.Size = new System.Drawing.Size(20, 12);
            this.baamount1.TabIndex = 70;
            this.baamount1.Text = "???";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(627, 416);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 12);
            this.label21.TabIndex = 71;
            this.label21.Text = "v 2.1.0";
            // 
            // INITM
            // 
            this.INITM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.INITM.Location = new System.Drawing.Point(501, 59);
            this.INITM.Margin = new System.Windows.Forms.Padding(2);
            this.INITM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.INITM.Name = "INITM";
            this.INITM.Size = new System.Drawing.Size(62, 19);
            this.INITM.TabIndex = 72;
            this.INITM.ValueChanged += new System.EventHandler(this.INITM_ValueChanged);
            // 
            // DIFFM
            // 
            this.DIFFM.Location = new System.Drawing.Point(501, 82);
            this.DIFFM.Margin = new System.Windows.Forms.Padding(2);
            this.DIFFM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.DIFFM.Name = "DIFFM";
            this.DIFFM.Size = new System.Drawing.Size(62, 19);
            this.DIFFM.TabIndex = 73;
            this.DIFFM.ValueChanged += new System.EventHandler(this.DIFFM_ValueChanged);
            // 
            // ScoreCal_Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 437);
            this.Controls.Add(this.DIFFM);
            this.Controls.Add(this.INITM);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.baamount1);
            this.Controls.Add(this.basum1);
            this.Controls.Add(this.baamount0);
            this.Controls.Add(this.basum0);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Diff比率);
            this.Controls.Add(this.スコア基準);
            this.Controls.Add(this.ScoreUD);
            this.Controls.Add(this.re);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SCOREDIFF);
            this.Controls.Add(this.SCOREINIT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gtdk4);
            this.Controls.Add(this.gdk4);
            this.Controls.Add(this.ntdk4);
            this.Controls.Add(this.ndk4);
            this.Controls.Add(this.gtdk3);
            this.Controls.Add(this.gdk3);
            this.Controls.Add(this.ntdk3);
            this.Controls.Add(this.ndk3);
            this.Controls.Add(this.gtdk2);
            this.Controls.Add(this.gdk2);
            this.Controls.Add(this.ntdk2);
            this.Controls.Add(this.ndk2);
            this.Controls.Add(this.gtdk1);
            this.Controls.Add(this.gdk1);
            this.Controls.Add(this.ntdk1);
            this.Controls.Add(this.ndk1);
            this.Controls.Add(this.gtdk0);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gdk0);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ntdk0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ndk0);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TJAName);
            this.Controls.Add(this.TJAReader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScoreCal_Form1";
            this.Text = "TJAScoreCalculator";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ScoreCal_Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScoreCal_Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diff比率)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.INITM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIFFM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SCOREINIT;
        private System.Windows.Forms.Label SCOREDIFF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label スコア基準;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Button TJAReader;
        public System.Windows.Forms.NumericUpDown ScoreUD;
        public System.Windows.Forms.NumericUpDown Diff比率;
        public System.Windows.Forms.NumericUpDown INITM;
        public System.Windows.Forms.NumericUpDown DIFFM;
        public System.Windows.Forms.Label re;
        public System.Windows.Forms.Label Total;
        public System.Windows.Forms.Label Difficulty;
        public System.Windows.Forms.Label ndk0;
        public System.Windows.Forms.Label ntdk0;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label gdk0;
        public System.Windows.Forms.Label gtdk0;
        public System.Windows.Forms.Label ndk1;
        public System.Windows.Forms.Label ntdk1;
        public System.Windows.Forms.Label gdk1;
        public System.Windows.Forms.Label gtdk1;
        public System.Windows.Forms.Label ndk2;
        public System.Windows.Forms.Label ntdk2;
        public System.Windows.Forms.Label gdk2;
        public System.Windows.Forms.Label gtdk2;
        public System.Windows.Forms.Label ndk3;
        public System.Windows.Forms.Label ntdk3;
        public System.Windows.Forms.Label gdk3;
        public System.Windows.Forms.Label gtdk3;
        public System.Windows.Forms.Label ndk4;
        public System.Windows.Forms.Label ntdk4;
        public System.Windows.Forms.Label gdk4;
        public System.Windows.Forms.Label gtdk4;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label basum0;
        public System.Windows.Forms.Label baamount0;
        public System.Windows.Forms.Label basum1;
        public System.Windows.Forms.Label baamount1;
        public System.Windows.Forms.Label TJAName;
        public System.Windows.Forms.TextBox textBox1;
    }
}

