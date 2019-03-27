namespace BeatSwapper
{
    partial class BeatSwapper
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeatSwapper));
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.stopPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.thirtyTwoBit = new System.Windows.Forms.RadioButton();
            this.twentyFourBit = new System.Windows.Forms.RadioButton();
            this.DimaBachilo = new System.Windows.Forms.RadioButton();
            this.eightBit = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sixCh = new System.Windows.Forms.RadioButton();
            this.fourCh = new System.Windows.Forms.RadioButton();
            this.twoCh = new System.Windows.Forms.RadioButton();
            this.fiveCh = new System.Windows.Forms.RadioButton();
            this.threeCh = new System.Windows.Forms.RadioButton();
            this.oneCh = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.threeFourEightKhz = new System.Windows.Forms.RadioButton();
            this.oneNineTwoKhz = new System.Windows.Forms.RadioButton();
            this.oneSevenSixKhz = new System.Windows.Forms.RadioButton();
            this.ninetySixKhz = new System.Windows.Forms.RadioButton();
            this.eightyEightKhz = new System.Windows.Forms.RadioButton();
            this.twentyFourKhz = new System.Windows.Forms.RadioButton();
            this.fourtyEightKhz = new System.Windows.Forms.RadioButton();
            this.twelweKhz = new System.Windows.Forms.RadioButton();
            this.elevenKhz = new System.Windows.Forms.RadioButton();
            this.eightKhz = new System.Windows.Forms.RadioButton();
            this.fourtyFourKhz = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.twentyTwoKhz = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.swapButton = new System.Windows.Forms.Button();
            this.offsetText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.about = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(506, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "WAV file|*.wav";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(488, 20);
            this.textBox1.TabIndex = 1;
            // 
            // previewButton
            // 
            this.previewButton.Enabled = false;
            this.previewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.previewButton.Location = new System.Drawing.Point(13, 117);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(122, 64);
            this.previewButton.TabIndex = 2;
            this.previewButton.Text = "PLAY";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // stopPreview
            // 
            this.stopPreview.Enabled = false;
            this.stopPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopPreview.Location = new System.Drawing.Point(141, 117);
            this.stopPreview.Name = "stopPreview";
            this.stopPreview.Size = new System.Drawing.Size(81, 64);
            this.stopPreview.TabIndex = 3;
            this.stopPreview.Text = "Stop";
            this.stopPreview.UseVisualStyleBackColor = true;
            this.stopPreview.Click += new System.EventHandler(this.stopPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.thirtyTwoBit);
            this.groupBox1.Controls.Add(this.twentyFourBit);
            this.groupBox1.Controls.Add(this.DimaBachilo);
            this.groupBox1.Controls.Add(this.eightBit);
            this.groupBox1.Location = new System.Drawing.Point(141, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bit depth";
            // 
            // thirtyTwoBit
            // 
            this.thirtyTwoBit.AutoSize = true;
            this.thirtyTwoBit.Enabled = false;
            this.thirtyTwoBit.Location = new System.Drawing.Point(44, 44);
            this.thirtyTwoBit.Name = "thirtyTwoBit";
            this.thirtyTwoBit.Size = new System.Drawing.Size(37, 17);
            this.thirtyTwoBit.TabIndex = 3;
            this.thirtyTwoBit.TabStop = true;
            this.thirtyTwoBit.Text = "32";
            this.thirtyTwoBit.UseVisualStyleBackColor = true;
            this.thirtyTwoBit.CheckedChanged += new System.EventHandler(this.thirtyTwoBit_CheckedChanged);
            // 
            // twentyFourBit
            // 
            this.twentyFourBit.AutoSize = true;
            this.twentyFourBit.Enabled = false;
            this.twentyFourBit.Location = new System.Drawing.Point(7, 44);
            this.twentyFourBit.Name = "twentyFourBit";
            this.twentyFourBit.Size = new System.Drawing.Size(37, 17);
            this.twentyFourBit.TabIndex = 2;
            this.twentyFourBit.TabStop = true;
            this.twentyFourBit.Text = "24";
            this.twentyFourBit.UseVisualStyleBackColor = true;
            this.twentyFourBit.CheckedChanged += new System.EventHandler(this.twentyFourBit_CheckedChanged);
            // 
            // DimaBachilo
            // 
            this.DimaBachilo.AutoSize = true;
            this.DimaBachilo.Enabled = false;
            this.DimaBachilo.Location = new System.Drawing.Point(44, 19);
            this.DimaBachilo.Name = "DimaBachilo";
            this.DimaBachilo.Size = new System.Drawing.Size(37, 17);
            this.DimaBachilo.TabIndex = 1;
            this.DimaBachilo.TabStop = true;
            this.DimaBachilo.Text = "16";
            this.DimaBachilo.UseVisualStyleBackColor = true;
            this.DimaBachilo.CheckedChanged += new System.EventHandler(this.DimaBachilo_CheckedChanged);
            // 
            // eightBit
            // 
            this.eightBit.AutoSize = true;
            this.eightBit.Enabled = false;
            this.eightBit.Location = new System.Drawing.Point(7, 20);
            this.eightBit.Name = "eightBit";
            this.eightBit.Size = new System.Drawing.Size(31, 17);
            this.eightBit.TabIndex = 0;
            this.eightBit.TabStop = true;
            this.eightBit.Text = "8";
            this.eightBit.UseVisualStyleBackColor = true;
            this.eightBit.CheckedChanged += new System.EventHandler(this.eightBit_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sixCh);
            this.groupBox2.Controls.Add(this.fourCh);
            this.groupBox2.Controls.Add(this.twoCh);
            this.groupBox2.Controls.Add(this.fiveCh);
            this.groupBox2.Controls.Add(this.threeCh);
            this.groupBox2.Controls.Add(this.oneCh);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 71);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channels";
            // 
            // sixCh
            // 
            this.sixCh.AutoSize = true;
            this.sixCh.Enabled = false;
            this.sixCh.Location = new System.Drawing.Point(82, 44);
            this.sixCh.Name = "sixCh";
            this.sixCh.Size = new System.Drawing.Size(31, 17);
            this.sixCh.TabIndex = 5;
            this.sixCh.TabStop = true;
            this.sixCh.Text = "6";
            this.sixCh.UseVisualStyleBackColor = true;
            this.sixCh.CheckedChanged += new System.EventHandler(this.sixCh_CheckedChanged);
            // 
            // fourCh
            // 
            this.fourCh.AutoSize = true;
            this.fourCh.Enabled = false;
            this.fourCh.Location = new System.Drawing.Point(7, 44);
            this.fourCh.Name = "fourCh";
            this.fourCh.Size = new System.Drawing.Size(31, 17);
            this.fourCh.TabIndex = 4;
            this.fourCh.TabStop = true;
            this.fourCh.Text = "4";
            this.fourCh.UseVisualStyleBackColor = true;
            this.fourCh.CheckedChanged += new System.EventHandler(this.fourCh_CheckedChanged);
            // 
            // twoCh
            // 
            this.twoCh.AutoSize = true;
            this.twoCh.Enabled = false;
            this.twoCh.Location = new System.Drawing.Point(45, 20);
            this.twoCh.Name = "twoCh";
            this.twoCh.Size = new System.Drawing.Size(31, 17);
            this.twoCh.TabIndex = 3;
            this.twoCh.TabStop = true;
            this.twoCh.Text = "2";
            this.twoCh.UseVisualStyleBackColor = true;
            this.twoCh.CheckedChanged += new System.EventHandler(this.twoCh_CheckedChanged);
            // 
            // fiveCh
            // 
            this.fiveCh.AutoSize = true;
            this.fiveCh.Enabled = false;
            this.fiveCh.Location = new System.Drawing.Point(44, 44);
            this.fiveCh.Name = "fiveCh";
            this.fiveCh.Size = new System.Drawing.Size(31, 17);
            this.fiveCh.TabIndex = 2;
            this.fiveCh.TabStop = true;
            this.fiveCh.Text = "5";
            this.fiveCh.UseVisualStyleBackColor = true;
            this.fiveCh.CheckedChanged += new System.EventHandler(this.fiveCh_CheckedChanged);
            // 
            // threeCh
            // 
            this.threeCh.AutoSize = true;
            this.threeCh.Enabled = false;
            this.threeCh.Location = new System.Drawing.Point(82, 20);
            this.threeCh.Name = "threeCh";
            this.threeCh.Size = new System.Drawing.Size(31, 17);
            this.threeCh.TabIndex = 1;
            this.threeCh.TabStop = true;
            this.threeCh.Text = "3";
            this.threeCh.UseVisualStyleBackColor = true;
            this.threeCh.CheckedChanged += new System.EventHandler(this.threeCh_CheckedChanged);
            // 
            // oneCh
            // 
            this.oneCh.AutoSize = true;
            this.oneCh.Enabled = false;
            this.oneCh.Location = new System.Drawing.Point(7, 20);
            this.oneCh.Name = "oneCh";
            this.oneCh.Size = new System.Drawing.Size(31, 17);
            this.oneCh.TabIndex = 0;
            this.oneCh.TabStop = true;
            this.oneCh.Text = "1";
            this.oneCh.UseVisualStyleBackColor = true;
            this.oneCh.CheckedChanged += new System.EventHandler(this.oneCh_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.threeFourEightKhz);
            this.groupBox3.Controls.Add(this.oneNineTwoKhz);
            this.groupBox3.Controls.Add(this.oneSevenSixKhz);
            this.groupBox3.Controls.Add(this.ninetySixKhz);
            this.groupBox3.Controls.Add(this.eightyEightKhz);
            this.groupBox3.Controls.Add(this.twentyFourKhz);
            this.groupBox3.Controls.Add(this.fourtyEightKhz);
            this.groupBox3.Controls.Add(this.twelweKhz);
            this.groupBox3.Controls.Add(this.elevenKhz);
            this.groupBox3.Controls.Add(this.eightKhz);
            this.groupBox3.Controls.Add(this.fourtyFourKhz);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.twentyTwoKhz);
            this.groupBox3.Location = new System.Drawing.Point(233, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 141);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frequency";
            // 
            // threeFourEightKhz
            // 
            this.threeFourEightKhz.AutoSize = true;
            this.threeFourEightKhz.Enabled = false;
            this.threeFourEightKhz.Location = new System.Drawing.Point(135, 113);
            this.threeFourEightKhz.Name = "threeFourEightKhz";
            this.threeFourEightKhz.Size = new System.Drawing.Size(61, 17);
            this.threeFourEightKhz.TabIndex = 12;
            this.threeFourEightKhz.TabStop = true;
            this.threeFourEightKhz.Text = "384000";
            this.threeFourEightKhz.UseVisualStyleBackColor = true;
            this.threeFourEightKhz.CheckedChanged += new System.EventHandler(this.threeFourEightKhz_CheckedChanged);
            // 
            // oneNineTwoKhz
            // 
            this.oneNineTwoKhz.AutoSize = true;
            this.oneNineTwoKhz.Enabled = false;
            this.oneNineTwoKhz.Location = new System.Drawing.Point(68, 113);
            this.oneNineTwoKhz.Name = "oneNineTwoKhz";
            this.oneNineTwoKhz.Size = new System.Drawing.Size(61, 17);
            this.oneNineTwoKhz.TabIndex = 11;
            this.oneNineTwoKhz.TabStop = true;
            this.oneNineTwoKhz.Text = "192000";
            this.oneNineTwoKhz.UseVisualStyleBackColor = true;
            this.oneNineTwoKhz.CheckedChanged += new System.EventHandler(this.oneNineTwoKhz_CheckedChanged);
            // 
            // oneSevenSixKhz
            // 
            this.oneSevenSixKhz.AutoSize = true;
            this.oneSevenSixKhz.Enabled = false;
            this.oneSevenSixKhz.Location = new System.Drawing.Point(6, 113);
            this.oneSevenSixKhz.Name = "oneSevenSixKhz";
            this.oneSevenSixKhz.Size = new System.Drawing.Size(61, 17);
            this.oneSevenSixKhz.TabIndex = 10;
            this.oneSevenSixKhz.TabStop = true;
            this.oneSevenSixKhz.Text = "176400";
            this.oneSevenSixKhz.UseVisualStyleBackColor = true;
            this.oneSevenSixKhz.CheckedChanged += new System.EventHandler(this.oneSevenSixKhz_CheckedChanged);
            // 
            // ninetySixKhz
            // 
            this.ninetySixKhz.AutoSize = true;
            this.ninetySixKhz.Enabled = false;
            this.ninetySixKhz.Location = new System.Drawing.Point(135, 90);
            this.ninetySixKhz.Name = "ninetySixKhz";
            this.ninetySixKhz.Size = new System.Drawing.Size(55, 17);
            this.ninetySixKhz.TabIndex = 9;
            this.ninetySixKhz.TabStop = true;
            this.ninetySixKhz.Text = "96000";
            this.ninetySixKhz.UseVisualStyleBackColor = true;
            this.ninetySixKhz.CheckedChanged += new System.EventHandler(this.ninetySixKhz_CheckedChanged);
            // 
            // eightyEightKhz
            // 
            this.eightyEightKhz.AutoSize = true;
            this.eightyEightKhz.Enabled = false;
            this.eightyEightKhz.Location = new System.Drawing.Point(68, 90);
            this.eightyEightKhz.Name = "eightyEightKhz";
            this.eightyEightKhz.Size = new System.Drawing.Size(55, 17);
            this.eightyEightKhz.TabIndex = 8;
            this.eightyEightKhz.TabStop = true;
            this.eightyEightKhz.Text = "88200";
            this.eightyEightKhz.UseVisualStyleBackColor = true;
            this.eightyEightKhz.CheckedChanged += new System.EventHandler(this.eightyEightKhz_CheckedChanged);
            // 
            // twentyFourKhz
            // 
            this.twentyFourKhz.AutoSize = true;
            this.twentyFourKhz.Enabled = false;
            this.twentyFourKhz.Location = new System.Drawing.Point(68, 67);
            this.twentyFourKhz.Name = "twentyFourKhz";
            this.twentyFourKhz.Size = new System.Drawing.Size(55, 17);
            this.twentyFourKhz.TabIndex = 7;
            this.twentyFourKhz.TabStop = true;
            this.twentyFourKhz.Text = "24000";
            this.twentyFourKhz.UseVisualStyleBackColor = true;
            this.twentyFourKhz.CheckedChanged += new System.EventHandler(this.twentyFourKhz_CheckedChanged);
            // 
            // fourtyEightKhz
            // 
            this.fourtyEightKhz.AutoSize = true;
            this.fourtyEightKhz.Enabled = false;
            this.fourtyEightKhz.Location = new System.Drawing.Point(6, 90);
            this.fourtyEightKhz.Name = "fourtyEightKhz";
            this.fourtyEightKhz.Size = new System.Drawing.Size(55, 17);
            this.fourtyEightKhz.TabIndex = 5;
            this.fourtyEightKhz.TabStop = true;
            this.fourtyEightKhz.Text = "48000";
            this.fourtyEightKhz.UseVisualStyleBackColor = true;
            this.fourtyEightKhz.CheckedChanged += new System.EventHandler(this.fourtyEightKhz_CheckedChanged);
            // 
            // twelweKhz
            // 
            this.twelweKhz.AutoSize = true;
            this.twelweKhz.Enabled = false;
            this.twelweKhz.Location = new System.Drawing.Point(135, 44);
            this.twelweKhz.Name = "twelweKhz";
            this.twelweKhz.Size = new System.Drawing.Size(55, 17);
            this.twelweKhz.TabIndex = 6;
            this.twelweKhz.TabStop = true;
            this.twelweKhz.Text = "12000";
            this.twelweKhz.UseVisualStyleBackColor = true;
            this.twelweKhz.CheckedChanged += new System.EventHandler(this.twelweKhz_CheckedChanged);
            // 
            // elevenKhz
            // 
            this.elevenKhz.AutoSize = true;
            this.elevenKhz.Enabled = false;
            this.elevenKhz.Location = new System.Drawing.Point(68, 44);
            this.elevenKhz.Name = "elevenKhz";
            this.elevenKhz.Size = new System.Drawing.Size(55, 17);
            this.elevenKhz.TabIndex = 2;
            this.elevenKhz.TabStop = true;
            this.elevenKhz.Text = "11250";
            this.elevenKhz.UseVisualStyleBackColor = true;
            this.elevenKhz.CheckedChanged += new System.EventHandler(this.elevenKhz_CheckedChanged);
            // 
            // eightKhz
            // 
            this.eightKhz.AutoSize = true;
            this.eightKhz.Enabled = false;
            this.eightKhz.Location = new System.Drawing.Point(6, 44);
            this.eightKhz.Name = "eightKhz";
            this.eightKhz.Size = new System.Drawing.Size(49, 17);
            this.eightKhz.TabIndex = 1;
            this.eightKhz.TabStop = true;
            this.eightKhz.Text = "8000";
            this.eightKhz.UseVisualStyleBackColor = true;
            this.eightKhz.CheckedChanged += new System.EventHandler(this.eightKhz_CheckedChanged);
            // 
            // fourtyFourKhz
            // 
            this.fourtyFourKhz.AutoSize = true;
            this.fourtyFourKhz.Enabled = false;
            this.fourtyFourKhz.Location = new System.Drawing.Point(135, 67);
            this.fourtyFourKhz.Name = "fourtyFourKhz";
            this.fourtyFourKhz.Size = new System.Drawing.Size(55, 17);
            this.fourtyFourKhz.TabIndex = 4;
            this.fourtyFourKhz.TabStop = true;
            this.fourtyFourKhz.Text = "44100";
            this.fourtyFourKhz.UseVisualStyleBackColor = true;
            this.fourtyFourKhz.CheckedChanged += new System.EventHandler(this.fourtyFourKhz_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // twentyTwoKhz
            // 
            this.twentyTwoKhz.AutoSize = true;
            this.twentyTwoKhz.Enabled = false;
            this.twentyTwoKhz.Location = new System.Drawing.Point(6, 67);
            this.twentyTwoKhz.Name = "twentyTwoKhz";
            this.twentyTwoKhz.Size = new System.Drawing.Size(55, 17);
            this.twentyTwoKhz.TabIndex = 3;
            this.twentyTwoKhz.TabStop = true;
            this.twentyTwoKhz.Text = "22050";
            this.twentyTwoKhz.UseVisualStyleBackColor = true;
            this.twentyTwoKhz.CheckedChanged += new System.EventHandler(this.twentyTwoKhz_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(527, 35);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(54, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "WAV file|*.wav";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(436, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Swap beats";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(436, 117);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(64, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BPM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // swapButton
            // 
            this.swapButton.Enabled = false;
            this.swapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.swapButton.Location = new System.Drawing.Point(506, 117);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(75, 67);
            this.swapButton.TabIndex = 11;
            this.swapButton.Text = "Swap!";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // offsetText
            // 
            this.offsetText.Enabled = false;
            this.offsetText.Location = new System.Drawing.Point(436, 161);
            this.offsetText.Name = "offsetText";
            this.offsetText.Size = new System.Drawing.Size(64, 20);
            this.offsetText.TabIndex = 12;
            this.offsetText.Text = "0";
            this.offsetText.TextChanged += new System.EventHandler(this.offsetText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Offset (sec)";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(448, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1 and 3";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(448, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2 and 4";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(527, 91);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(54, 23);
            this.about.TabIndex = 16;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // BeatSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 185);
            this.Controls.Add(this.about);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.offsetText);
            this.Controls.Add(this.swapButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stopPreview);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BeatSwapper";
            this.Text = "BeatSwapper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button stopPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton thirtyTwoBit;
        private System.Windows.Forms.RadioButton twentyFourBit;
        private System.Windows.Forms.RadioButton DimaBachilo;
        private System.Windows.Forms.RadioButton eightBit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton sixCh;
        private System.Windows.Forms.RadioButton fourCh;
        private System.Windows.Forms.RadioButton twoCh;
        private System.Windows.Forms.RadioButton fiveCh;
        private System.Windows.Forms.RadioButton threeCh;
        private System.Windows.Forms.RadioButton oneCh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton threeFourEightKhz;
        private System.Windows.Forms.RadioButton oneNineTwoKhz;
        private System.Windows.Forms.RadioButton oneSevenSixKhz;
        private System.Windows.Forms.RadioButton ninetySixKhz;
        private System.Windows.Forms.RadioButton eightyEightKhz;
        private System.Windows.Forms.RadioButton twentyFourKhz;
        private System.Windows.Forms.RadioButton fourtyEightKhz;
        private System.Windows.Forms.RadioButton twelweKhz;
        private System.Windows.Forms.RadioButton elevenKhz;
        private System.Windows.Forms.RadioButton eightKhz;
        private System.Windows.Forms.RadioButton fourtyFourKhz;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton twentyTwoKhz;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.TextBox offsetText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button about;
    }
}

