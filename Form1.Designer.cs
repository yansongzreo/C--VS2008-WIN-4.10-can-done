namespace WindowsApplication1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_devtype = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Time1 = new System.Windows.Forms.TextBox();
            this.textBox_AccMask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.textBox_Time0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CANIndex = new System.Windows.Forms.ComboBox();
            this.comboBox_DevIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button_StartCAN = new System.Windows.Forms.Button();
            this.button_StopCAN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_FrameFormat = new System.Windows.Forms.ComboBox();
            this.comboBox_FrameType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox_Info = new System.Windows.Forms.ListBox();
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_devtype);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox_CANIndex);
            this.groupBox1.Controls.Add(this.comboBox_DevIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            // 
            // comboBox_devtype
            // 
            this.comboBox_devtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_devtype.FormattingEnabled = true;
            this.comboBox_devtype.Items.AddRange(new object[] {
            "3",
            "4"});
            this.comboBox_devtype.Location = new System.Drawing.Point(51, 19);
            this.comboBox_devtype.MaxDropDownItems = 15;
            this.comboBox_devtype.Name = "comboBox_devtype";
            this.comboBox_devtype.Size = new System.Drawing.Size(121, 20);
            this.comboBox_devtype.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "类型:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Time1);
            this.groupBox2.Controls.Add(this.textBox_AccMask);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_Mode);
            this.groupBox2.Controls.Add(this.comboBox_Filter);
            this.groupBox2.Controls.Add(this.textBox_Time0);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_AccCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初始化CAN参数";
            // 
            // textBox_Time1
            // 
            this.textBox_Time1.Location = new System.Drawing.Point(218, 46);
            this.textBox_Time1.Name = "textBox_Time1";
            this.textBox_Time1.Size = new System.Drawing.Size(28, 21);
            this.textBox_Time1.TabIndex = 1;
            // 
            // textBox_AccMask
            // 
            this.textBox_AccMask.Location = new System.Drawing.Point(74, 46);
            this.textBox_AccMask.Name = "textBox_AccMask";
            this.textBox_AccMask.Size = new System.Drawing.Size(70, 21);
            this.textBox_AccMask.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "定时器1:0x";
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Items.AddRange(new object[] {
            "正常",
            "只听",
            "自测"});
            this.comboBox_Mode.Location = new System.Drawing.Point(317, 48);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Mode.TabIndex = 1;
            // 
            // comboBox_Filter
            // 
            this.comboBox_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Items.AddRange(new object[] {
            "接收全部类型",
            "只接收标准帧",
            "只接收扩展帧"});
            this.comboBox_Filter.Location = new System.Drawing.Point(317, 21);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Filter.TabIndex = 1;
            // 
            // textBox_Time0
            // 
            this.textBox_Time0.Location = new System.Drawing.Point(218, 19);
            this.textBox_Time0.Name = "textBox_Time0";
            this.textBox_Time0.Size = new System.Drawing.Size(28, 21);
            this.textBox_Time0.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "模式:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "滤波方式:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "屏蔽码:0x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "定时器0:0x";
            // 
            // textBox_AccCode
            // 
            this.textBox_AccCode.Location = new System.Drawing.Point(74, 19);
            this.textBox_AccCode.Name = "textBox_AccCode";
            this.textBox_AccCode.Size = new System.Drawing.Size(70, 21);
            this.textBox_AccCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "验收码:0x";
            // 
            // comboBox_CANIndex
            // 
            this.comboBox_CANIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CANIndex.FormattingEnabled = true;
            this.comboBox_CANIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_CANIndex.Location = new System.Drawing.Point(368, 23);
            this.comboBox_CANIndex.Name = "comboBox_CANIndex";
            this.comboBox_CANIndex.Size = new System.Drawing.Size(47, 20);
            this.comboBox_CANIndex.TabIndex = 1;
            // 
            // comboBox_DevIndex
            // 
            this.comboBox_DevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DevIndex.FormattingEnabled = true;
            this.comboBox_DevIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_DevIndex.Location = new System.Drawing.Point(238, 23);
            this.comboBox_DevIndex.Name = "comboBox_DevIndex";
            this.comboBox_DevIndex.Size = new System.Drawing.Size(41, 20);
            this.comboBox_DevIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "第几路CAN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "索引号:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(452, 39);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button_StartCAN
            // 
            this.button_StartCAN.Location = new System.Drawing.Point(452, 87);
            this.button_StartCAN.Name = "button_StartCAN";
            this.button_StartCAN.Size = new System.Drawing.Size(75, 23);
            this.button_StartCAN.TabIndex = 5;
            this.button_StartCAN.Text = "启动CAN";
            this.button_StartCAN.UseVisualStyleBackColor = true;
            this.button_StartCAN.Click += new System.EventHandler(this.button_StartCAN_Click);
            // 
            // button_StopCAN
            // 
            this.button_StopCAN.Location = new System.Drawing.Point(452, 136);
            this.button_StopCAN.Name = "button_StopCAN";
            this.button_StopCAN.Size = new System.Drawing.Size(75, 23);
            this.button_StopCAN.TabIndex = 5;
            this.button_StopCAN.Text = "复位CAN";
            this.button_StopCAN.UseVisualStyleBackColor = true;
            this.button_StopCAN.Click += new System.EventHandler(this.button_StopCAN_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_FrameFormat);
            this.groupBox3.Controls.Add(this.comboBox_FrameType);
            this.groupBox3.Controls.Add(this.button_Send);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox_Data);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox_ID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 81);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据帧";
            // 
            // comboBox_FrameFormat
            // 
            this.comboBox_FrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameFormat.FormattingEnabled = true;
            this.comboBox_FrameFormat.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.comboBox_FrameFormat.Location = new System.Drawing.Point(196, 19);
            this.comboBox_FrameFormat.Name = "comboBox_FrameFormat";
            this.comboBox_FrameFormat.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameFormat.TabIndex = 1;
            // 
            // comboBox_FrameType
            // 
            this.comboBox_FrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameType.FormattingEnabled = true;
            this.comboBox_FrameType.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.comboBox_FrameType.Location = new System.Drawing.Point(69, 20);
            this.comboBox_FrameType.Name = "comboBox_FrameType";
            this.comboBox_FrameType.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameType.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(325, 47);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 5;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "帧格式:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "帧类型:";
            // 
            // textBox_Data
            // 
            this.textBox_Data.Location = new System.Drawing.Point(56, 48);
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(251, 21);
            this.textBox_Data.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "数据:";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(322, 18);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(70, 21);
            this.textBox_ID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(272, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "帧ID:0x";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox_Info);
            this.groupBox4.Location = new System.Drawing.Point(12, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(515, 206);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "信息";
            // 
            // listBox_Info
            // 
            this.listBox_Info.FormattingEnabled = true;
            this.listBox_Info.ItemHeight = 12;
            this.listBox_Info.Location = new System.Drawing.Point(12, 20);
            this.listBox_Info.Name = "listBox_Info";
            this.listBox_Info.Size = new System.Drawing.Size(490, 172);
            this.listBox_Info.TabIndex = 0;
            // 
            // timer_rec
            // 
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(452, 180);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 8;
            this.button_Clear.Text = "清空列表";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(9, 20);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(97, 38);
            this.button_Stop.TabIndex = 9;
            this.button_Stop.Text = "停止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 33);
            this.button2.TabIndex = 10;
            this.button2.Text = "速度模式开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(208, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "获取电机速度";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button28);
            this.groupBox5.Controls.Add(this.button26);
            this.groupBox5.Controls.Add(this.button27);
            this.groupBox5.Controls.Add(this.button24);
            this.groupBox5.Controls.Add(this.button25);
            this.groupBox5.Controls.Add(this.button23);
            this.groupBox5.Controls.Add(this.button21);
            this.groupBox5.Controls.Add(this.button22);
            this.groupBox5.Controls.Add(this.button19);
            this.groupBox5.Controls.Add(this.button20);
            this.groupBox5.Controls.Add(this.button13);
            this.groupBox5.Controls.Add(this.button14);
            this.groupBox5.Controls.Add(this.button15);
            this.groupBox5.Controls.Add(this.button16);
            this.groupBox5.Controls.Add(this.button17);
            this.groupBox5.Controls.Add(this.button18);
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.button_Stop);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(546, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(516, 436);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "电机操作";
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(208, 370);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(172, 23);
            this.button26.TabIndex = 36;
            this.button26.Text = "设置位置并获取电流速度位置";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(9, 364);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(122, 35);
            this.button27.TabIndex = 35;
            this.button27.Text = "位置模式开始";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(208, 291);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(172, 23);
            this.button24.TabIndex = 34;
            this.button24.Text = "设置电流并获取电流速度位置";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(9, 286);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(122, 33);
            this.button25.TabIndex = 33;
            this.button25.Text = "电流模式开始";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(208, 330);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(172, 23);
            this.button23.TabIndex = 32;
            this.button23.Text = "设置速度并获取电流速度位置";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(389, 197);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(117, 23);
            this.button21.TabIndex = 31;
            this.button21.Text = "电路板温度";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(269, 197);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(114, 23);
            this.button22.TabIndex = 30;
            this.button22.Text = "电机温度";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(129, 239);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(117, 23);
            this.button19.TabIndex = 29;
            this.button19.Text = "最小负向位置";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(9, 239);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(114, 23);
            this.button20.TabIndex = 28;
            this.button20.Text = "最大正向位置";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(129, 155);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(117, 23);
            this.button13.TabIndex = 27;
            this.button13.Text = "最小负向允许速度";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(9, 155);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(114, 23);
            this.button14.TabIndex = 26;
            this.button14.Text = "最大正向允许速度";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(329, 155);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 25;
            this.button15.Text = "减速度";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(248, 155);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 24;
            this.button16.Text = "加速度";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(90, 197);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 23;
            this.button17.Text = "最小负电流";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(9, 197);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 22;
            this.button18.Text = "最大正电流";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(171, 197);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(92, 23);
            this.button12.TabIndex = 21;
            this.button12.Text = "获取母线电压";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(421, 114);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "位置环微分";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(340, 114);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 19;
            this.button10.Text = "位置环积分";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(259, 114);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 18;
            this.button11.Text = "位置环比例";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(171, 114);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "速度环微分";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(90, 114);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "速度环积分";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "速度环比例";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(308, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "获取电机位置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(109, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "获取电机电流";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "获取运行模式";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(406, 70);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(87, 23);
            this.button28.TabIndex = 37;
            this.button28.Text = "电机目标位置";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 461);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_StopCAN);
            this.Controls.Add(this.button_StartCAN);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "USB CAN Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBox_CANIndex;
        private System.Windows.Forms.ComboBox comboBox_DevIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Time1;
        private System.Windows.Forms.TextBox textBox_AccMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Time0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_StartCAN;
        private System.Windows.Forms.Button button_StopCAN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_FrameFormat;
        private System.Windows.Forms.ComboBox comboBox_FrameType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox_Info;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.ComboBox comboBox_devtype;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button28;
    }
}

