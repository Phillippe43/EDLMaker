namespace EDLMplayerTimeConversion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxStart = new System.Windows.Forms.CheckBox();
            this.checkBoxEnd = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ScanLbl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnChgTime = new System.Windows.Forms.Button();
            this.MUTE = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(918, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 249);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(971, 586);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "EXIT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1186, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(565, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 54);
            this.label6.TabIndex = 10;
            this.label6.Text = "This button is used to convert time to seconds and\r\nadd the mute action beside th" +
    "e time. It will discard\r\neverything else leaving the new created file able to \r\n" +
    "be used with Mplayer. ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1247, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 130);
            this.label7.TabIndex = 12;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1310, 516);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1286, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Enter seconds and/or milliseconds";
            // 
            // checkBoxStart
            // 
            this.checkBoxStart.AutoSize = true;
            this.checkBoxStart.Location = new System.Drawing.Point(1310, 570);
            this.checkBoxStart.Name = "checkBoxStart";
            this.checkBoxStart.Size = new System.Drawing.Size(74, 17);
            this.checkBoxStart.TabIndex = 17;
            this.checkBoxStart.Text = "Start Time";
            this.checkBoxStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnd
            // 
            this.checkBoxEnd.AutoSize = true;
            this.checkBoxEnd.Location = new System.Drawing.Point(1310, 593);
            this.checkBoxEnd.Name = "checkBoxEnd";
            this.checkBoxEnd.Size = new System.Drawing.Size(71, 17);
            this.checkBoxEnd.TabIndex = 18;
            this.checkBoxEnd.Text = "End Time";
            this.checkBoxEnd.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1286, 616);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Check which time to change";
            // 
            // ScanLbl
            // 
            this.ScanLbl.AutoSize = true;
            this.ScanLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScanLbl.Location = new System.Drawing.Point(172, 329);
            this.ScanLbl.Name = "ScanLbl";
            this.ScanLbl.Size = new System.Drawing.Size(300, 67);
            this.ScanLbl.TabIndex = 21;
            this.ScanLbl.Text = resources.GetString("ScanLbl.Text");
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::EDLMplayerTimeConversion.Properties.Resources.glasses;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(153, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 316);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChgTime
            // 
            this.btnChgTime.BackgroundImage = global::EDLMplayerTimeConversion.Properties.Resources.time;
            this.btnChgTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChgTime.Location = new System.Drawing.Point(1202, 12);
            this.btnChgTime.Name = "btnChgTime";
            this.btnChgTime.Size = new System.Drawing.Size(341, 315);
            this.btnChgTime.TabIndex = 11;
            this.btnChgTime.UseVisualStyleBackColor = true;
            this.btnChgTime.Click += new System.EventHandler(this.btnChgTime_Click);
            // 
            // MUTE
            // 
            this.MUTE.BackgroundImage = global::EDLMplayerTimeConversion.Properties.Resources.Mute_button_icon_1106121401;
            this.MUTE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MUTE.Location = new System.Drawing.Point(519, 12);
            this.MUTE.Name = "MUTE";
            this.MUTE.Size = new System.Drawing.Size(347, 315);
            this.MUTE.TabIndex = 3;
            this.MUTE.UseVisualStyleBackColor = true;
            this.MUTE.Click += new System.EventHandler(this.MUTE_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Image = global::EDLMplayerTimeConversion.Properties.Resources.skip;
            this.button1.Location = new System.Drawing.Point(881, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 315);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SkipScene_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1577, 679);
            this.Controls.Add(this.ScanLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBoxEnd);
            this.Controls.Add(this.checkBoxStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnChgTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.MUTE);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button MUTE;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChgTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxStart;
        private System.Windows.Forms.CheckBox checkBoxEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ScanLbl;

    }
}

