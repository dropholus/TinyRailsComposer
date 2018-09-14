namespace MyControls
{
	partial class NumberControl
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
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_PM = new MyControls.Button();
            this.Btn_Back = new MyControls.Button();
            this.Btn_CE = new MyControls.Button();
            this.button2 = new MyControls.Button();
            this.Btn_Ok = new MyControls.Button();
            this.Btn_3 = new MyControls.Button();
            this.Btn_6 = new MyControls.Button();
            this.Btn_9 = new MyControls.Button();
            this.Btn_0 = new MyControls.Button();
            this.Btn_2 = new MyControls.Button();
            this.Btn_5 = new MyControls.Button();
            this.Btn_8 = new MyControls.Button();
            this.Btn_1 = new MyControls.Button();
            this.Btn_4 = new MyControls.Button();
            this.Btn_7 = new MyControls.Button();
            this.Btn_FulFill = new MyControls.Button();
            this.Btn_Reuse = new MyControls.Button();
            this.SuspendLayout();
            // 
            // TxtNumber
            // 
            this.TxtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNumber.Location = new System.Drawing.Point(3, 12);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Size = new System.Drawing.Size(181, 20);
            this.TxtNumber.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(821, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "CE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnCE_Click);
            // 
            // Btn_PM
            // 
            this.Btn_PM.BackColor = System.Drawing.Color.Transparent;
            this.Btn_PM.ClickOnMouseUp = false;
            this.Btn_PM.Color = System.Drawing.Color.LightSkyBlue;
            this.Btn_PM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_PM.Location = new System.Drawing.Point(12, 206);
            this.Btn_PM.Name = "Btn_PM";
            this.Btn_PM.Size = new System.Drawing.Size(50, 50);
            this.Btn_PM.TabIndex = 4;
            this.Btn_PM.Text = "+ -";
            this.Btn_PM.Click += new System.EventHandler(this.BtnPM_Click);
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Back.ClickOnMouseUp = false;
            this.Btn_Back.Color = System.Drawing.Color.Azure;
            this.Btn_Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Back.Location = new System.Drawing.Point(124, 262);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(50, 50);
            this.Btn_Back.TabIndex = 4;
            this.Btn_Back.Text = "<";
            this.Btn_Back.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // Btn_CE
            // 
            this.Btn_CE.BackColor = System.Drawing.Color.Transparent;
            this.Btn_CE.ClickOnMouseUp = false;
            this.Btn_CE.Color = System.Drawing.Color.Azure;
            this.Btn_CE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_CE.Location = new System.Drawing.Point(124, 206);
            this.Btn_CE.Name = "Btn_CE";
            this.Btn_CE.Size = new System.Drawing.Size(50, 50);
            this.Btn_CE.TabIndex = 3;
            this.Btn_CE.Text = "CE";
            this.Btn_CE.Click += new System.EventHandler(this.BtnCE_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.ClickOnMouseUp = false;
            this.button2.Color = System.Drawing.Color.Firebrick;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(68, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Ok.ClickOnMouseUp = false;
            this.Btn_Ok.Color = System.Drawing.Color.Green;
            this.Btn_Ok.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Ok.Location = new System.Drawing.Point(12, 262);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(50, 50);
            this.Btn_Ok.TabIndex = 3;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // Btn_3
            // 
            this.Btn_3.BackColor = System.Drawing.Color.Transparent;
            this.Btn_3.ClickOnMouseUp = false;
            this.Btn_3.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_3.Location = new System.Drawing.Point(124, 150);
            this.Btn_3.Name = "Btn_3";
            this.Btn_3.Size = new System.Drawing.Size(50, 50);
            this.Btn_3.TabIndex = 2;
            this.Btn_3.Text = "3";
            this.Btn_3.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_6
            // 
            this.Btn_6.BackColor = System.Drawing.Color.Transparent;
            this.Btn_6.ClickOnMouseUp = false;
            this.Btn_6.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_6.Location = new System.Drawing.Point(124, 94);
            this.Btn_6.Name = "Btn_6";
            this.Btn_6.Size = new System.Drawing.Size(50, 50);
            this.Btn_6.TabIndex = 2;
            this.Btn_6.Text = "6";
            this.Btn_6.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_9
            // 
            this.Btn_9.BackColor = System.Drawing.Color.Transparent;
            this.Btn_9.ClickOnMouseUp = false;
            this.Btn_9.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_9.Location = new System.Drawing.Point(124, 38);
            this.Btn_9.Name = "Btn_9";
            this.Btn_9.Size = new System.Drawing.Size(50, 50);
            this.Btn_9.TabIndex = 2;
            this.Btn_9.Text = "9";
            this.Btn_9.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_0
            // 
            this.Btn_0.BackColor = System.Drawing.Color.Transparent;
            this.Btn_0.ClickOnMouseUp = false;
            this.Btn_0.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_0.Location = new System.Drawing.Point(68, 206);
            this.Btn_0.Name = "Btn_0";
            this.Btn_0.Size = new System.Drawing.Size(50, 50);
            this.Btn_0.TabIndex = 2;
            this.Btn_0.Text = "0";
            this.Btn_0.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_2
            // 
            this.Btn_2.BackColor = System.Drawing.Color.Transparent;
            this.Btn_2.ClickOnMouseUp = false;
            this.Btn_2.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_2.Location = new System.Drawing.Point(68, 150);
            this.Btn_2.Name = "Btn_2";
            this.Btn_2.Size = new System.Drawing.Size(50, 50);
            this.Btn_2.TabIndex = 2;
            this.Btn_2.Text = "2";
            this.Btn_2.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_5
            // 
            this.Btn_5.BackColor = System.Drawing.Color.Transparent;
            this.Btn_5.ClickOnMouseUp = false;
            this.Btn_5.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_5.Location = new System.Drawing.Point(68, 94);
            this.Btn_5.Name = "Btn_5";
            this.Btn_5.Size = new System.Drawing.Size(50, 50);
            this.Btn_5.TabIndex = 2;
            this.Btn_5.Text = "5";
            this.Btn_5.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_8
            // 
            this.Btn_8.BackColor = System.Drawing.Color.Transparent;
            this.Btn_8.ClickOnMouseUp = false;
            this.Btn_8.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_8.Location = new System.Drawing.Point(68, 38);
            this.Btn_8.Name = "Btn_8";
            this.Btn_8.Size = new System.Drawing.Size(50, 50);
            this.Btn_8.TabIndex = 2;
            this.Btn_8.Text = "8";
            this.Btn_8.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_1
            // 
            this.Btn_1.BackColor = System.Drawing.Color.Transparent;
            this.Btn_1.ClickOnMouseUp = false;
            this.Btn_1.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_1.Location = new System.Drawing.Point(12, 150);
            this.Btn_1.Name = "Btn_1";
            this.Btn_1.Size = new System.Drawing.Size(50, 50);
            this.Btn_1.TabIndex = 2;
            this.Btn_1.Text = "1";
            this.Btn_1.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_4
            // 
            this.Btn_4.BackColor = System.Drawing.Color.Transparent;
            this.Btn_4.ClickOnMouseUp = false;
            this.Btn_4.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_4.Location = new System.Drawing.Point(12, 94);
            this.Btn_4.Name = "Btn_4";
            this.Btn_4.Size = new System.Drawing.Size(50, 50);
            this.Btn_4.TabIndex = 2;
            this.Btn_4.Text = "4";
            this.Btn_4.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_7
            // 
            this.Btn_7.BackColor = System.Drawing.Color.Transparent;
            this.Btn_7.ClickOnMouseUp = false;
            this.Btn_7.Color = System.Drawing.Color.DodgerBlue;
            this.Btn_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_7.Location = new System.Drawing.Point(12, 38);
            this.Btn_7.Name = "Btn_7";
            this.Btn_7.Size = new System.Drawing.Size(50, 50);
            this.Btn_7.TabIndex = 2;
            this.Btn_7.Text = "7";
            this.Btn_7.Click += new System.EventHandler(this.BtnNumber_Click);
            // 
            // Btn_FulFill
            // 
            this.Btn_FulFill.BackColor = System.Drawing.Color.Transparent;
            this.Btn_FulFill.ClickOnMouseUp = false;
            this.Btn_FulFill.Color = System.Drawing.Color.LimeGreen;
            this.Btn_FulFill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_FulFill.Location = new System.Drawing.Point(12, 318);
            this.Btn_FulFill.Name = "Btn_FulFill";
            this.Btn_FulFill.Size = new System.Drawing.Size(50, 50);
            this.Btn_FulFill.TabIndex = 10;
            this.Btn_FulFill.Text = "Fill";
            this.Btn_FulFill.Click += new System.EventHandler(this.Btn_FulFill_Click);
            // 
            // Btn_Reuse
            // 
            this.Btn_Reuse.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Reuse.ClickOnMouseUp = false;
            this.Btn_Reuse.Color = System.Drawing.Color.GreenYellow;
            this.Btn_Reuse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Reuse.Location = new System.Drawing.Point(68, 318);
            this.Btn_Reuse.Name = "Btn_Reuse";
            this.Btn_Reuse.Size = new System.Drawing.Size(50, 50);
            this.Btn_Reuse.TabIndex = 10;
            this.Btn_Reuse.Text = "Reuse";
            this.Btn_Reuse.Click += new System.EventHandler(this.Btn_Reuse_Click);
            // 
            // NumberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.Btn_PM);
            this.Controls.Add(this.Btn_Back);
            this.Controls.Add(this.Btn_CE);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Btn_3);
            this.Controls.Add(this.Btn_6);
            this.Controls.Add(this.Btn_9);
            this.Controls.Add(this.Btn_0);
            this.Controls.Add(this.Btn_2);
            this.Controls.Add(this.Btn_5);
            this.Controls.Add(this.Btn_8);
            this.Controls.Add(this.Btn_1);
            this.Controls.Add(this.Btn_4);
            this.Controls.Add(this.Btn_7);
            this.Controls.Add(this.TxtNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Reuse);
            this.Controls.Add(this.Btn_FulFill);
            this.Name = "NumberControl";
            this.Size = new System.Drawing.Size(187, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtNumber;
		private Button Btn_7;
		private System.Windows.Forms.Button button1;
		private Button Btn_8;
		private Button Btn_9;
		private Button Btn_4;
		private Button Btn_5;
		private Button Btn_6;
		private Button Btn_1;
		private Button Btn_2;
		private Button Btn_3;
		private Button Btn_0;
		private Button Btn_Ok;
		private Button button2;
		private Button Btn_CE;
		private Button Btn_Back;
		private Button Btn_PM;
		private Button Btn_FulFill;
        private Button Btn_Reuse;
    }
}
