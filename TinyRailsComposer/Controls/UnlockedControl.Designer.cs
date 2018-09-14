namespace TinyRails_Composer.Controls
{
	partial class UnlockedControl
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
			this.ChkRegion = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// ChkRegion
			// 
			this.ChkRegion.Location = new System.Drawing.Point(3, 3);
			this.ChkRegion.Name = "ChkRegion";
			this.ChkRegion.Size = new System.Drawing.Size(144, 16);
			this.ChkRegion.TabIndex = 0;
			this.ChkRegion.Text = "checkBox1";
			this.ChkRegion.UseVisualStyleBackColor = true;
			// 
			// UnlockedControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ChkRegion);
			this.Name = "UnlockedControl";
			this.Size = new System.Drawing.Size(150, 24);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox ChkRegion;
	}
}
