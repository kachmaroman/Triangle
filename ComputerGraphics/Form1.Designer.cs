namespace ComputerGraphics
{
	sealed partial class Form1
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
			this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxGrid
			// 
			this.pictureBoxGrid.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxGrid.Name = "pictureBoxGrid";
			this.pictureBoxGrid.Size = new System.Drawing.Size(800, 800);
			this.pictureBoxGrid.TabIndex = 1;
			this.pictureBoxGrid.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 827);
			this.Controls.Add(this.pictureBoxGrid);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBoxGrid;
	}
}

