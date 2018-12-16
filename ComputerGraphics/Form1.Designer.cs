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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nupFirstY = new System.Windows.Forms.NumericUpDown();
			this.nupFirstX = new System.Windows.Forms.NumericUpDown();
			this.nupSecondX = new System.Windows.Forms.NumericUpDown();
			this.nupSecondY = new System.Windows.Forms.NumericUpDown();
			this.btnAddSquare = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.trackBar = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(818, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Верхня вершина (ліва)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(818, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(18, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(819, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "X";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(819, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "X";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(819, 169);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(18, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Y";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(818, 111);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(189, 20);
			this.label6.TabIndex = 7;
			this.label6.Text = "Нижня вершина (права)";
			// 
			// nupFirstY
			// 
			this.nupFirstY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupFirstY.Location = new System.Drawing.Point(843, 72);
			this.nupFirstY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nupFirstY.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
			this.nupFirstY.Name = "nupFirstY";
			this.nupFirstY.ReadOnly = true;
			this.nupFirstY.Size = new System.Drawing.Size(70, 20);
			this.nupFirstY.TabIndex = 12;
			// 
			// nupFirstX
			// 
			this.nupFirstX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupFirstX.Location = new System.Drawing.Point(843, 42);
			this.nupFirstX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nupFirstX.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
			this.nupFirstX.Name = "nupFirstX";
			this.nupFirstX.ReadOnly = true;
			this.nupFirstX.Size = new System.Drawing.Size(70, 20);
			this.nupFirstX.TabIndex = 13;
			// 
			// nupSecondX
			// 
			this.nupSecondX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupSecondX.Location = new System.Drawing.Point(843, 137);
			this.nupSecondX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nupSecondX.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
			this.nupSecondX.Name = "nupSecondX";
			this.nupSecondX.ReadOnly = true;
			this.nupSecondX.Size = new System.Drawing.Size(70, 20);
			this.nupSecondX.TabIndex = 15;
			// 
			// nupSecondY
			// 
			this.nupSecondY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupSecondY.Location = new System.Drawing.Point(843, 167);
			this.nupSecondY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nupSecondY.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
			this.nupSecondY.Name = "nupSecondY";
			this.nupSecondY.ReadOnly = true;
			this.nupSecondY.Size = new System.Drawing.Size(70, 20);
			this.nupSecondY.TabIndex = 14;
			// 
			// btnAddSquare
			// 
			this.btnAddSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddSquare.Location = new System.Drawing.Point(822, 295);
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
			this.btnClear.Location = new System.Drawing.Point(823, 362);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(174, 41);
			this.btnClear.TabIndex = 21;
			this.btnClear.Text = "Очистити";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// trackBar
			// 
			this.trackBar.Location = new System.Drawing.Point(822, 244);
			this.trackBar.Maximum = 5;
			this.trackBar.Minimum = 1;
			this.trackBar.Name = "trackBar";
			this.trackBar.Size = new System.Drawing.Size(174, 45);
			this.trackBar.TabIndex = 22;
			this.trackBar.Value = 1;
			this.trackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(818, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(123, 20);
			this.label7.TabIndex = 23;
			this.label7.Text = "Розмір відрізка";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 826);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.trackBar);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAddSquare);
			this.Controls.Add(this.nupSecondX);
			this.Controls.Add(this.nupSecondY);
			this.Controls.Add(this.nupFirstX);
			this.Controls.Add(this.nupFirstY);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxGrid);
			this.MaximumSize = new System.Drawing.Size(1028, 865);
			this.MinimumSize = new System.Drawing.Size(1028, 865);
			this.Name = "Form1";
			this.Text = "Побудова квадратів за заданими координатами";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBoxGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nupFirstY;
		private System.Windows.Forms.NumericUpDown nupFirstX;
		private System.Windows.Forms.NumericUpDown nupSecondX;
		private System.Windows.Forms.NumericUpDown nupSecondY;
		private System.Windows.Forms.Button btnAddSquare;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.Label label7;
	}
}

