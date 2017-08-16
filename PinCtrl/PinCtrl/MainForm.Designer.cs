namespace PinCtrl
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOutExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConAnaly = new System.Windows.Forms.Button();
            this.btnSetAy = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnReadAy = new System.Windows.Forms.Button();
            this.tbYScale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbAverNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBandSpan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSpan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMarker = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSetModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.buttonOpenClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbNi = new System.Windows.Forms.RadioButton();
            this.rbShun = new System.Windows.Forms.RadioButton();
            this.rbAround = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.btnGoZero = new System.Windows.Forms.Button();
            this.tbDu = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(1, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 502);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "频谱仪读数实时显示";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(270, 482);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(684, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 538);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作日志";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(6, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(217, 515);
            this.textBox1.TabIndex = 1;
            // 
            // btnOutExcel
            // 
            this.btnOutExcel.Location = new System.Drawing.Point(178, 517);
            this.btnOutExcel.Name = "btnOutExcel";
            this.btnOutExcel.Size = new System.Drawing.Size(96, 27);
            this.btnOutExcel.TabIndex = 10;
            this.btnOutExcel.Text = "导出Excel";
            this.btnOutExcel.UseVisualStyleBackColor = true;
            this.btnOutExcel.Click += new System.EventHandler(this.OutputExcel);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConAnaly);
            this.groupBox4.Controls.Add(this.btnSetAy);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnReadAy);
            this.groupBox4.Controls.Add(this.tbYScale);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.tbAverNumber);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tbBandSpan);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbSpan);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbMarker);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbFreq);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cbSetModel);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(283, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 262);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "频谱仪设置";
            // 
            // btnConAnaly
            // 
            this.btnConAnaly.Location = new System.Drawing.Point(49, 211);
            this.btnConAnaly.Name = "btnConAnaly";
            this.btnConAnaly.Size = new System.Drawing.Size(92, 26);
            this.btnConAnaly.TabIndex = 21;
            this.btnConAnaly.Text = "连接频谱仪";
            this.btnConAnaly.UseVisualStyleBackColor = true;
            this.btnConAnaly.Click += new System.EventHandler(this.btnConAnaly_Click);
            // 
            // btnSetAy
            // 
            this.btnSetAy.Location = new System.Drawing.Point(289, 211);
            this.btnSetAy.Name = "btnSetAy";
            this.btnSetAy.Size = new System.Drawing.Size(92, 26);
            this.btnSetAy.TabIndex = 20;
            this.btnSetAy.Text = "设置";
            this.btnSetAy.UseVisualStyleBackColor = true;
            this.btnSetAy.Click += new System.EventHandler(this.btnSetAy_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "dBm";
            // 
            // btnReadAy
            // 
            this.btnReadAy.Location = new System.Drawing.Point(169, 211);
            this.btnReadAy.Name = "btnReadAy";
            this.btnReadAy.Size = new System.Drawing.Size(92, 26);
            this.btnReadAy.TabIndex = 18;
            this.btnReadAy.Text = "读取";
            this.btnReadAy.UseVisualStyleBackColor = true;
            this.btnReadAy.Click += new System.EventHandler(this.btnReadAy_Click);
            // 
            // tbYScale
            // 
            this.tbYScale.Location = new System.Drawing.Point(289, 156);
            this.tbYScale.Name = "tbYScale";
            this.tbYScale.Size = new System.Drawing.Size(70, 21);
            this.tbYScale.TabIndex = 17;
            this.tbYScale.Text = "-10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "AMPTD Y Scale:";
            // 
            // tbAverNumber
            // 
            this.tbAverNumber.Location = new System.Drawing.Point(289, 106);
            this.tbAverNumber.Name = "tbAverNumber";
            this.tbAverNumber.Size = new System.Drawing.Size(70, 21);
            this.tbAverNumber.TabIndex = 15;
            this.tbAverNumber.Text = "20";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "Average Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(365, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "MHz";
            // 
            // tbBandSpan
            // 
            this.tbBandSpan.Location = new System.Drawing.Point(289, 62);
            this.tbBandSpan.Name = "tbBandSpan";
            this.tbBandSpan.Size = new System.Drawing.Size(70, 21);
            this.tbBandSpan.TabIndex = 12;
            this.tbBandSpan.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Band SPAN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "MHz";
            // 
            // tbSpan
            // 
            this.tbSpan.Location = new System.Drawing.Point(71, 156);
            this.tbSpan.Name = "tbSpan";
            this.tbSpan.Size = new System.Drawing.Size(70, 21);
            this.tbSpan.TabIndex = 9;
            this.tbSpan.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "SPAN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "GHz";
            // 
            // tbMarker
            // 
            this.tbMarker.Location = new System.Drawing.Point(71, 106);
            this.tbMarker.Name = "tbMarker";
            this.tbMarker.Size = new System.Drawing.Size(70, 21);
            this.tbMarker.TabIndex = 6;
            this.tbMarker.Text = "5.79";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Marker:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "GHz";
            // 
            // tbFreq
            // 
            this.tbFreq.Location = new System.Drawing.Point(71, 62);
            this.tbFreq.Name = "tbFreq";
            this.tbFreq.Size = new System.Drawing.Size(70, 21);
            this.tbFreq.TabIndex = 3;
            this.tbFreq.Text = "5.79";
            this.tbFreq.TextChanged += new System.EventHandler(this.tbFreq_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "FREQ:";
            // 
            // cbSetModel
            // 
            this.cbSetModel.FormattingEnabled = true;
            this.cbSetModel.Items.AddRange(new object[] {
            "频率"});
            this.cbSetModel.Location = new System.Drawing.Point(71, 22);
            this.cbSetModel.Name = "cbSetModel";
            this.cbSetModel.Size = new System.Drawing.Size(70, 20);
            this.cbSetModel.TabIndex = 1;
            this.cbSetModel.Text = "频率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "测量参数:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择串口：";
            // 
            // comboPortName
            // 
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(77, 27);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(121, 20);
            this.comboPortName.TabIndex = 2;
            // 
            // buttonOpenClose
            // 
            this.buttonOpenClose.Location = new System.Drawing.Point(214, 23);
            this.buttonOpenClose.Name = "buttonOpenClose";
            this.buttonOpenClose.Size = new System.Drawing.Size(85, 27);
            this.buttonOpenClose.TabIndex = 4;
            this.buttonOpenClose.Text = "打开串口";
            this.buttonOpenClose.UseVisualStyleBackColor = true;
            this.buttonOpenClose.Click += new System.EventHandler(this.buttonOpenClose_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.buttonOpenClose);
            this.groupBox1.Controls.Add(this.comboPortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(283, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "转台设置";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.rbAround);
            this.groupBox5.Controls.Add(this.rbSingle);
            this.groupBox5.Controls.Add(this.btnGoZero);
            this.groupBox5.Controls.Add(this.tbDu);
            this.groupBox5.Controls.Add(this.btnStop);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.tbSpeed);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(6, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(380, 208);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "转动设置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbNi);
            this.panel1.Controls.Add(this.rbShun);
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 33);
            this.panel1.TabIndex = 21;
            // 
            // rbNi
            // 
            this.rbNi.AutoSize = true;
            this.rbNi.Location = new System.Drawing.Point(101, 8);
            this.rbNi.Name = "rbNi";
            this.rbNi.Size = new System.Drawing.Size(59, 16);
            this.rbNi.TabIndex = 22;
            this.rbNi.Text = "逆时针";
            this.rbNi.UseVisualStyleBackColor = true;
            // 
            // rbShun
            // 
            this.rbShun.AutoSize = true;
            this.rbShun.Checked = true;
            this.rbShun.Location = new System.Drawing.Point(8, 8);
            this.rbShun.Name = "rbShun";
            this.rbShun.Size = new System.Drawing.Size(59, 16);
            this.rbShun.TabIndex = 21;
            this.rbShun.TabStop = true;
            this.rbShun.Text = "顺时针";
            this.rbShun.UseVisualStyleBackColor = true;
            // 
            // rbAround
            // 
            this.rbAround.AutoSize = true;
            this.rbAround.Checked = true;
            this.rbAround.Location = new System.Drawing.Point(107, 20);
            this.rbAround.Name = "rbAround";
            this.rbAround.Size = new System.Drawing.Size(71, 16);
            this.rbAround.TabIndex = 20;
            this.rbAround.TabStop = true;
            this.rbAround.Text = "连续转动";
            this.rbAround.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(14, 20);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(71, 16);
            this.rbSingle.TabIndex = 19;
            this.rbSingle.Text = "单步转动";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbSingle_CheckedChanged);
            // 
            // btnGoZero
            // 
            this.btnGoZero.Location = new System.Drawing.Point(253, 104);
            this.btnGoZero.Name = "btnGoZero";
            this.btnGoZero.Size = new System.Drawing.Size(100, 30);
            this.btnGoZero.TabIndex = 18;
            this.btnGoZero.Text = "归零";
            this.btnGoZero.UseVisualStyleBackColor = true;
            this.btnGoZero.Click += new System.EventHandler(this.btnGoZero_Click);
            // 
            // tbDu
            // 
            this.tbDu.Location = new System.Drawing.Point(78, 109);
            this.tbDu.Name = "tbDu";
            this.tbDu.Size = new System.Drawing.Size(100, 21);
            this.tbDu.TabIndex = 13;
            this.tbDu.Text = "360";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(253, 148);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "设置速度";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(78, 145);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "开始转动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(78, 82);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(100, 21);
            this.tbSpeed.TabIndex = 10;
            this.tbSpeed.Text = "500";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(184, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "°（度）";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(184, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "毫秒每度";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "转动角度";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 551);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(143, 12);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "万集科技 v1.0 @20170325";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(53, 517);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 27);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(925, 565);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOutExcel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "频谱仪-转台上位机软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOutExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbBandSpan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSpan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMarker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSetModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPortName;
        private System.Windows.Forms.Button buttonOpenClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnSetAy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnReadAy;
        private System.Windows.Forms.TextBox tbYScale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbAverNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbNi;
        private System.Windows.Forms.RadioButton rbShun;
        private System.Windows.Forms.RadioButton rbAround;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.Button btnGoZero;
        private System.Windows.Forms.TextBox tbDu;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConAnaly;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}

