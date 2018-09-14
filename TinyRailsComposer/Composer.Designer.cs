namespace TinyRails_Composer
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.FlpUnlockedRegions = new System.Windows.Forms.FlowLayoutPanel();
			this.LblFilter = new System.Windows.Forms.Label();
			this.TxtFilter = new System.Windows.Forms.TextBox();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.ChkShowFulfilled = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.BtnSave = new System.Windows.Forms.Button();
			this.LblOptions = new System.Windows.Forms.Label();
			this.RadManual = new System.Windows.Forms.RadioButton();
			this.RadClose = new System.Windows.Forms.RadioButton();
			this.RadAuto = new System.Windows.Forms.RadioButton();
			this.numberControl1 = new MyControls.NumberControl();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.FlpShowOnly = new System.Windows.Forms.FlowLayoutPanel();
			this.TabOuter = new System.Windows.Forms.TabControl();
			this.Collected = new System.Windows.Forms.TabPage();
			this.NotCollected = new System.Windows.Forms.TabPage();
			this.NotCollectedView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.TabOuter.SuspendLayout();
			this.Collected.SuspendLayout();
			this.NotCollected.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NotCollectedView)).BeginInit();
			this.SuspendLayout();
			// 
			// FlpUnlockedRegions
			// 
			this.FlpUnlockedRegions.AutoScroll = true;
			this.FlpUnlockedRegions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlpUnlockedRegions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.FlpUnlockedRegions.Location = new System.Drawing.Point(3, 3);
			this.FlpUnlockedRegions.Name = "FlpUnlockedRegions";
			this.FlpUnlockedRegions.Size = new System.Drawing.Size(205, 515);
			this.FlpUnlockedRegions.TabIndex = 0;
			this.FlpUnlockedRegions.WrapContents = false;
			// 
			// LblFilter
			// 
			this.LblFilter.AutoSize = true;
			this.LblFilter.Location = new System.Drawing.Point(3, 6);
			this.LblFilter.Name = "LblFilter";
			this.LblFilter.Size = new System.Drawing.Size(29, 13);
			this.LblFilter.TabIndex = 2;
			this.LblFilter.Text = "Filter";
			// 
			// TxtFilter
			// 
			this.TxtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtFilter.Location = new System.Drawing.Point(38, 3);
			this.TxtFilter.Name = "TxtFilter";
			this.TxtFilter.Size = new System.Drawing.Size(383, 20);
			this.TxtFilter.TabIndex = 3;
			this.TxtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
			// 
			// DataGridView
			// 
			this.DataGridView.AllowUserToAddRows = false;
			this.DataGridView.AllowUserToDeleteRows = false;
			this.DataGridView.AllowUserToResizeRows = false;
			this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Location = new System.Drawing.Point(6, 29);
			this.DataGridView.MultiSelect = false;
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.ReadOnly = true;
			this.DataGridView.RowHeadersVisible = false;
			this.DataGridView.Size = new System.Drawing.Size(537, 509);
			this.DataGridView.TabIndex = 4;
			this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			this.DataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
			// 
			// ChkShowFulfilled
			// 
			this.ChkShowFulfilled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ChkShowFulfilled.AutoSize = true;
			this.ChkShowFulfilled.Location = new System.Drawing.Point(427, 6);
			this.ChkShowFulfilled.Name = "ChkShowFulfilled";
			this.ChkShowFulfilled.Size = new System.Drawing.Size(91, 17);
			this.ChkShowFulfilled.TabIndex = 5;
			this.ChkShowFulfilled.Text = "Show Fulfilled";
			this.ChkShowFulfilled.UseVisualStyleBackColor = true;
			this.ChkShowFulfilled.CheckedChanged += new System.EventHandler(this.RefreshFilter);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.LblFilter);
			this.panel2.Controls.Add(this.TxtFilter);
			this.panel2.Controls.Add(this.DataGridView);
			this.panel2.Controls.Add(this.ChkShowFulfilled);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(546, 547);
			this.panel2.TabIndex = 8;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.BtnSave);
			this.panel3.Controls.Add(this.LblOptions);
			this.panel3.Controls.Add(this.RadManual);
			this.panel3.Controls.Add(this.RadClose);
			this.panel3.Controls.Add(this.RadAuto);
			this.panel3.Location = new System.Drawing.Point(778, 426);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(187, 127);
			this.panel3.TabIndex = 9;
			// 
			// BtnSave
			// 
			this.BtnSave.Location = new System.Drawing.Point(65, 95);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 2;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.Save_Click);
			// 
			// LblOptions
			// 
			this.LblOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblOptions.Location = new System.Drawing.Point(3, 0);
			this.LblOptions.Name = "LblOptions";
			this.LblOptions.Size = new System.Drawing.Size(181, 23);
			this.LblOptions.TabIndex = 1;
			this.LblOptions.Text = "Save options";
			this.LblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadManual
			// 
			this.RadManual.AutoSize = true;
			this.RadManual.Location = new System.Drawing.Point(20, 72);
			this.RadManual.Name = "RadManual";
			this.RadManual.Size = new System.Drawing.Size(152, 17);
			this.RadManual.TabIndex = 0;
			this.RadManual.TabStop = true;
			this.RadManual.Text = "manual + on program close";
			this.RadManual.UseVisualStyleBackColor = true;
			this.RadManual.CheckedChanged += new System.EventHandler(this.RadManual_CheckedChanged);
			// 
			// RadClose
			// 
			this.RadClose.AutoSize = true;
			this.RadClose.Location = new System.Drawing.Point(20, 49);
			this.RadClose.Name = "RadClose";
			this.RadClose.Size = new System.Drawing.Size(108, 17);
			this.RadClose.TabIndex = 0;
			this.RadClose.TabStop = true;
			this.RadClose.Text = "On program close";
			this.RadClose.UseVisualStyleBackColor = true;
			this.RadClose.CheckedChanged += new System.EventHandler(this.RadClose_CheckedChanged);
			// 
			// RadAuto
			// 
			this.RadAuto.AutoSize = true;
			this.RadAuto.Location = new System.Drawing.Point(20, 26);
			this.RadAuto.Name = "RadAuto";
			this.RadAuto.Size = new System.Drawing.Size(132, 17);
			this.RadAuto.TabIndex = 0;
			this.RadAuto.TabStop = true;
			this.RadAuto.Text = "AutoSave (on change)";
			this.RadAuto.UseVisualStyleBackColor = true;
			this.RadAuto.CheckedChanged += new System.EventHandler(this.RadAuto_CheckedChanged);
			// 
			// numberControl1
			// 
			this.numberControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numberControl1.BackColor = System.Drawing.Color.LightGray;
			this.numberControl1.Location = new System.Drawing.Point(778, 6);
			this.numberControl1.Name = "numberControl1";
			this.numberControl1.Number = "";
			this.numberControl1.Size = new System.Drawing.Size(215, 410);
			this.numberControl1.TabIndex = 1;
			this.numberControl1.OnOk += new System.EventHandler<MyControls.NumberControl.NumberEventArgs>(this.NumberControl1_OnOk);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 6);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(769, 547);
			this.splitContainer1.SplitterDistance = 546;
			this.splitContainer1.TabIndex = 10;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(219, 547);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.FlpUnlockedRegions);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(211, 521);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Unlocked";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.FlpShowOnly);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(211, 521);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Show only";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// FlpShowOnly
			// 
			this.FlpShowOnly.AutoScroll = true;
			this.FlpShowOnly.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlpShowOnly.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.FlpShowOnly.Location = new System.Drawing.Point(3, 3);
			this.FlpShowOnly.Name = "FlpShowOnly";
			this.FlpShowOnly.Size = new System.Drawing.Size(205, 515);
			this.FlpShowOnly.TabIndex = 0;
			this.FlpShowOnly.WrapContents = false;
			// 
			// TabOuter
			// 
			this.TabOuter.Controls.Add(this.Collected);
			this.TabOuter.Controls.Add(this.NotCollected);
			this.TabOuter.Location = new System.Drawing.Point(12, 12);
			this.TabOuter.Name = "TabOuter";
			this.TabOuter.SelectedIndex = 0;
			this.TabOuter.Size = new System.Drawing.Size(1007, 585);
			this.TabOuter.TabIndex = 11;
			// 
			// Collected
			// 
			this.Collected.Controls.Add(this.splitContainer1);
			this.Collected.Controls.Add(this.numberControl1);
			this.Collected.Controls.Add(this.panel3);
			this.Collected.Location = new System.Drawing.Point(4, 22);
			this.Collected.Name = "Collected";
			this.Collected.Padding = new System.Windows.Forms.Padding(3);
			this.Collected.Size = new System.Drawing.Size(999, 559);
			this.Collected.TabIndex = 0;
			this.Collected.Text = "Resources Collected";
			this.Collected.UseVisualStyleBackColor = true;
			// 
			// NotCollected
			// 
			this.NotCollected.Controls.Add(this.NotCollectedView);
			this.NotCollected.Location = new System.Drawing.Point(4, 22);
			this.NotCollected.Name = "NotCollected";
			this.NotCollected.Padding = new System.Windows.Forms.Padding(3);
			this.NotCollected.Size = new System.Drawing.Size(999, 559);
			this.NotCollected.TabIndex = 1;
			this.NotCollected.Text = "NotCollected";
			this.NotCollected.UseVisualStyleBackColor = true;
			// 
			// NotCollectedView
			// 
			this.NotCollectedView.AllowUserToAddRows = false;
			this.NotCollectedView.AllowUserToDeleteRows = false;
			this.NotCollectedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.NotCollectedView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NotCollectedView.Location = new System.Drawing.Point(3, 3);
			this.NotCollectedView.Name = "NotCollectedView";
			this.NotCollectedView.ReadOnly = true;
			this.NotCollectedView.Size = new System.Drawing.Size(993, 553);
			this.NotCollectedView.TabIndex = 0;
			this.NotCollectedView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.NotCollectedView_CellFormatting);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1042, 622);
			this.Controls.Add(this.TabOuter);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "TinyRails Composer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.TabOuter.ResumeLayout(false);
			this.Collected.ResumeLayout(false);
			this.NotCollected.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NotCollectedView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel FlpUnlockedRegions;
		private MyControls.NumberControl numberControl1;
		private System.Windows.Forms.Label LblFilter;
		private System.Windows.Forms.TextBox TxtFilter;
		private System.Windows.Forms.DataGridView DataGridView;
		private System.Windows.Forms.CheckBox ChkShowFulfilled;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.Label LblOptions;
		private System.Windows.Forms.RadioButton RadManual;
		private System.Windows.Forms.RadioButton RadClose;
		private System.Windows.Forms.RadioButton RadAuto;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.FlowLayoutPanel FlpShowOnly;
		private System.Windows.Forms.TabControl TabOuter;
		private System.Windows.Forms.TabPage Collected;
		private System.Windows.Forms.TabPage NotCollected;
		private System.Windows.Forms.DataGridView NotCollectedView;
	}
}

