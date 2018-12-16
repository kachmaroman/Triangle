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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nupX = new System.Windows.Forms.NumericUpDown();
			this.nupY = new System.Windows.Forms.NumericUpDown();
			this.btnAddSquare = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nupDegree = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupDegree)).BeginInit();
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
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(820, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "X";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(820, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(18, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Y";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(819, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(106, 20);
			this.label6.TabIndex = 7;
			this.label6.Text = "Розтягнення";
			// 
			// nupX
			// 
			this.nupX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupX.Location = new System.Drawing.Point(861, 36);
			this.nupX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nupX.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.nupX.Name = "nupX";
			this.nupX.ReadOnly = true;
			this.nupX.Size = new System.Drawing.Size(70, 20);
			this.nupX.TabIndex = 15;
			// 
			// nupY
			// 
			this.nupY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupY.Location = new System.Drawing.Point(861, 66);
			this.nupY.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.nupY.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
			this.nupY.Name = "nupY";
			this.nupY.ReadOnly = true;
			this.nupY.Size = new System.Drawing.Size(70, 20);
			this.nupY.TabIndex = 14;
			// 
			// btnAddSquare
			// 
			this.btnAddSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddSquare.Location = new System.Drawing.Point(822, 210);
			this.btnAddSquare.Name = "btnAddSquare";
			this.btnAddSquare.Size = new System.Drawing.Size(175, 50);
			this.btnAddSquare.TabIndex = 16;
			this.btnAddSquare.Text = "Побудувати трикутник";
			this.btnAddSquare.UseVisualStyleBackColor = true;
			this.btnAddSquare.Click += new System.EventHandler(this.btnAddSquare_Click);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(823, 291);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(174, 41);
			this.btnClear.TabIndex = 21;
			this.btnClear.Text = "Очистити";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(937, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 24;
			this.label8.Text = "раз(и)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(937, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "раз(и)";
			// 
			// nupDegree
			// 
			this.nupDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupDegree.Location = new System.Drawing.Point(861, 155);
			this.nupDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.nupDegree.Name = "nupDegree";
			this.nupDegree.Size = new System.Drawing.Size(70, 20);
			this.nupDegree.TabIndex = 26;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(820, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 20);
			this.label3.TabIndex = 28;
			this.label3.Text = "Поворот";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(821, 156);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 29;
			this.label2.Text = "Кут";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 826);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nupDegree);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAddSquare);
			this.Controls.Add(this.nupX);
			this.Controls.Add(this.nupY);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pictureBoxGrid);
			this.MaximumSize = new System.Drawing.Size(1028, 865);
			this.MinimumSize = new System.Drawing.Size(1028, 865);
			this.Name = "Form1";
			this.Text = "Побудова трикутників";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupDegree)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBoxGrid;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nupX;
		private System.Windows.Forms.NumericUpDown nupY;
		private System.Windows.Forms.Button btnAddSquare;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nupDegree;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}

