namespace SDK_CSharp_Form
{
    partial class SOUND
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOUND));
            this.num_SoundReplayDelay = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cmb_SoundDataMode = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_SoundText = new System.Windows.Forms.TextBox();
            this.cmb_SoundSpeed = new System.Windows.Forms.ComboBox();
            this.cmb_SoundVolum = new System.Windows.Forms.ComboBox();
            this.cmb_SoundPerson = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.num_VoiceID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_SoundReplayTimes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Soundnumdeal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Soundwordstyle = new System.Windows.Forms.ComboBox();
            this.cmb_Soundlanguages = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_SoundReplayDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_VoiceID)).BeginInit();
            this.SuspendLayout();
            // 
            // num_SoundReplayDelay
            // 
            this.num_SoundReplayDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_SoundReplayDelay.Location = new System.Drawing.Point(112, 147);
            this.num_SoundReplayDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_SoundReplayDelay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_SoundReplayDelay.Name = "num_SoundReplayDelay";
            this.num_SoundReplayDelay.Size = new System.Drawing.Size(44, 23);
            this.num_SoundReplayDelay.TabIndex = 90;
            this.num_SoundReplayDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(109, 127);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 17);
            this.label27.TabIndex = 89;
            this.label27.Text = "重播间隔";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(24, 128);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 17);
            this.label26.TabIndex = 87;
            this.label26.Text = "重播次数";
            // 
            // cmb_SoundDataMode
            // 
            this.cmb_SoundDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SoundDataMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoundDataMode.FormattingEnabled = true;
            this.cmb_SoundDataMode.Items.AddRange(new object[] {
            "GB2312",
            "GBK",
            "BIG5",
            "UNICODE"});
            this.cmb_SoundDataMode.Location = new System.Drawing.Point(311, 31);
            this.cmb_SoundDataMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SoundDataMode.Name = "cmb_SoundDataMode";
            this.cmb_SoundDataMode.Size = new System.Drawing.Size(71, 25);
            this.cmb_SoundDataMode.TabIndex = 86;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(324, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 17);
            this.label25.TabIndex = 85;
            this.label25.Text = "编码";
            // 
            // txt_SoundText
            // 
            this.txt_SoundText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SoundText.Location = new System.Drawing.Point(9, 178);
            this.txt_SoundText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SoundText.Multiline = true;
            this.txt_SoundText.Name = "txt_SoundText";
            this.txt_SoundText.Size = new System.Drawing.Size(373, 61);
            this.txt_SoundText.TabIndex = 84;
            this.txt_SoundText.Text = "语音信息";
            // 
            // cmb_SoundSpeed
            // 
            this.cmb_SoundSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SoundSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoundSpeed.FormattingEnabled = true;
            this.cmb_SoundSpeed.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmb_SoundSpeed.Location = new System.Drawing.Point(247, 32);
            this.cmb_SoundSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SoundSpeed.Name = "cmb_SoundSpeed";
            this.cmb_SoundSpeed.Size = new System.Drawing.Size(48, 25);
            this.cmb_SoundSpeed.TabIndex = 83;
            // 
            // cmb_SoundVolum
            // 
            this.cmb_SoundVolum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SoundVolum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoundVolum.FormattingEnabled = true;
            this.cmb_SoundVolum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmb_SoundVolum.Location = new System.Drawing.Point(186, 32);
            this.cmb_SoundVolum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SoundVolum.Name = "cmb_SoundVolum";
            this.cmb_SoundVolum.Size = new System.Drawing.Size(48, 25);
            this.cmb_SoundVolum.TabIndex = 82;
            // 
            // cmb_SoundPerson
            // 
            this.cmb_SoundPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SoundPerson.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoundPerson.FormattingEnabled = true;
            this.cmb_SoundPerson.Items.AddRange(new object[] {
            "晓燕",
            "许久",
            "许多",
            "晓萍",
            "唐老鸭",
            "许小宝"});
            this.cmb_SoundPerson.Location = new System.Drawing.Point(73, 32);
            this.cmb_SoundPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SoundPerson.Name = "cmb_SoundPerson";
            this.cmb_SoundPerson.Size = new System.Drawing.Size(95, 25);
            this.cmb_SoundPerson.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(245, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 79;
            this.label9.Text = "语速";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(192, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 17);
            this.label22.TabIndex = 78;
            this.label22.Text = "音量";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(86, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 17);
            this.label23.TabIndex = 77;
            this.label23.Text = "发音人";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(235, 247);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 33);
            this.button2.TabIndex = 75;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(42, 247);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 74;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // num_VoiceID
            // 
            this.num_VoiceID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_VoiceID.Location = new System.Drawing.Point(13, 32);
            this.num_VoiceID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_VoiceID.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.num_VoiceID.Name = "num_VoiceID";
            this.num_VoiceID.Size = new System.Drawing.Size(44, 23);
            this.num_VoiceID.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "队列编号";
            // 
            // cmb_SoundReplayTimes
            // 
            this.cmb_SoundReplayTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SoundReplayTimes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoundReplayTimes.FormattingEnabled = true;
            this.cmb_SoundReplayTimes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "循环"});
            this.cmb_SoundReplayTimes.Location = new System.Drawing.Point(13, 145);
            this.cmb_SoundReplayTimes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SoundReplayTimes.Name = "cmb_SoundReplayTimes";
            this.cmb_SoundReplayTimes.Size = new System.Drawing.Size(71, 25);
            this.cmb_SoundReplayTimes.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(162, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 94;
            this.label2.Text = "10ms";
            // 
            // cmb_Soundnumdeal
            // 
            this.cmb_Soundnumdeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Soundnumdeal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Soundnumdeal.FormattingEnabled = true;
            this.cmb_Soundnumdeal.Items.AddRange(new object[] {
            "0：自动判断",
            "1：数字作号码处理 ",
            "2：数字作数值处理"});
            this.cmb_Soundnumdeal.Location = new System.Drawing.Point(10, 91);
            this.cmb_Soundnumdeal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Soundnumdeal.Name = "cmb_Soundnumdeal";
            this.cmb_Soundnumdeal.Size = new System.Drawing.Size(117, 25);
            this.cmb_Soundnumdeal.TabIndex = 195;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 194;
            this.label4.Text = "数字";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(150, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 196;
            this.label11.Text = "语种";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(272, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 197;
            this.label5.Text = "发音";
            // 
            // cmb_Soundwordstyle
            // 
            this.cmb_Soundwordstyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Soundwordstyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Soundwordstyle.FormattingEnabled = true;
            this.cmb_Soundwordstyle.Items.AddRange(new object[] {
            "0：自动判断发音方式 ",
            "1：字母发音方式 ",
            "2：单词发音方式 "});
            this.cmb_Soundwordstyle.Location = new System.Drawing.Point(267, 91);
            this.cmb_Soundwordstyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Soundwordstyle.Name = "cmb_Soundwordstyle";
            this.cmb_Soundwordstyle.Size = new System.Drawing.Size(117, 25);
            this.cmb_Soundwordstyle.TabIndex = 199;
            // 
            // cmb_Soundlanguages
            // 
            this.cmb_Soundlanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Soundlanguages.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Soundlanguages.FormattingEnabled = true;
            this.cmb_Soundlanguages.Items.AddRange(new object[] {
            "0：自动判断语种 ",
            "1：阿拉伯数字、度量单位、特殊 符号等合成为中文 ",
            "2：阿拉伯数字、度量单位、特殊 符号等合成为英"});
            this.cmb_Soundlanguages.Location = new System.Drawing.Point(144, 91);
            this.cmb_Soundlanguages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Soundlanguages.Name = "cmb_Soundlanguages";
            this.cmb_Soundlanguages.Size = new System.Drawing.Size(117, 25);
            this.cmb_Soundlanguages.TabIndex = 198;
            // 
            // SOUND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 290);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_Soundwordstyle);
            this.Controls.Add(this.cmb_Soundlanguages);
            this.Controls.Add(this.cmb_Soundnumdeal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_SoundReplayTimes);
            this.Controls.Add(this.num_VoiceID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_SoundReplayDelay);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmb_SoundDataMode);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txt_SoundText);
            this.Controls.Add(this.cmb_SoundSpeed);
            this.Controls.Add(this.cmb_SoundVolum);
            this.Controls.Add(this.cmb_SoundPerson);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SOUND";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOUND";
            ((System.ComponentModel.ISupportInitialize)(this.num_SoundReplayDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_VoiceID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_SoundReplayDelay;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmb_SoundDataMode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_SoundText;
        private System.Windows.Forms.ComboBox cmb_SoundSpeed;
        private System.Windows.Forms.ComboBox cmb_SoundVolum;
        private System.Windows.Forms.ComboBox cmb_SoundPerson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown num_VoiceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_SoundReplayTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Soundnumdeal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Soundwordstyle;
        private System.Windows.Forms.ComboBox cmb_Soundlanguages;
    }
}