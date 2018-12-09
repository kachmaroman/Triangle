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
			this.cdSquareColor = new System.Windows.Forms.ColorDialog();
			this.btnSquareColor = new System.Windows.Forms.Button();
			this.btnCircleColor = new System.Windows.Forms.Button();
			this.cdCircleColor = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondY)).BeginInit();
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
			this.label1.Location = new System.Drawing.Point(818, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Верхня вершина";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(818, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(818, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "X";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(818, 177);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "X";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(818, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Y";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(818, 118);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Нижня вершина (права)";
			// 
			// nupFirstY
			// 
			this.nupFirstY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nupFirstY.Location = new System.Drawing.Point(838, 36);
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
			this.nupFirstX.Location = new System.Drawing.Point(838, 69);
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
			this.nupSecondX.Location = new System.Drawing.Point(838, 175);
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
			this.nupSecondY.Location = new System.Drawing.Point(838, 142);
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
			this.btnAddSquare.Location = new System.Drawing.Point(818, 359);
			this.btnAddSquare.Name = "btnAddSquare";
			this.btnAddSquare.Size = new System.Drawing.Size(141, 50);
			this.btnAddSquare.TabIndex = 16;
			this.btnAddSquare.Text = "Побудувати квадрат";
			this.btnAddSquare.UseVisualStyleBackColor = true;
			this.btnAddSquare.Click += new System.EventHandler(this.btnAddSquare_Click);
			// 
			// btnSquareColor
			// 
			this.btnSquareColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSquareColor.Location = new System.Drawing.Point(818, 216);
			this.btnSquareColor.Name = "btnSquareColor";
			this.btnSquareColor.Size = new System.Drawing.Size(141, 54);
			this.btnSquareColor.TabIndex = 18;
			this.btnSquareColor.Text = "Колір межі квадрату";
			this.btnSquareColor.UseVisualStyleBackColor = true;
			this.btnSquareColor.Click += new System.EventHandler(this.btnSquareColor_Click);
			// 
			// btnCircleColor
			// 
			this.btnCircleColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCircleColor.Location = new System.Drawing.Point(818, 276);
			this.btnCircleColor.Name = "btnCircleColor";
			this.btnCircleColor.Size = new System.Drawing.Size(141, 54);
			this.btnCircleColor.TabIndex = 19;
			this.btnCircleColor.Text = "Колір заливки кола";
			this.btnCircleColor.UseVisualStyleBackColor = true;
			this.btnCircleColor.Click += new System.EventHandler(this.btnCircleColor_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 825);
			this.Controls.Add(this.btnCircleColor);
			this.Controls.Add(this.btnSquareColor);
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
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupFirstX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupSecondY)).EndInit();
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
		private System.Windows.Forms.ColorDialog cdSquareColor;
		private System.Windows.Forms.Button btnSquareColor;
		private System.Windows.Forms.Button btnCircleColor;
		private System.Windows.Forms.ColorDialog cdCircleColor;
	}
}

