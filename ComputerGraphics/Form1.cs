using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
	public sealed partial class Form1 : Form
	{
		private const int NumOfCells = 100;
		private const int CellSize = 20;
		private const int Offset = 5;
		private const int NumberOfAngles = 4;
		private const int UpUpSpaceFromCoordinateLine = 25;
		private const int BottomSpaceFromCoordinateLine = 10;

		private int CellSpace;
		private int MaxValueOfCoordinate;

		private int MaxValueOfNumericUpDown;
		private int MinValueOfNumbericUpDown;

		private Bitmap image;
		private Pen pen;

		public Form1()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{
			CellSpace = trackBar.Value * CellSize;
			MaxValueOfCoordinate = Convert.ToInt32(Math.Ceiling(pictureBoxGrid.Height / 2.0 / CellSpace));

			MaxValueOfNumericUpDown = MaxValueOfCoordinate - 1;
			MinValueOfNumbericUpDown = MaxValueOfNumericUpDown * -1;

			nupFirstX.Minimum = MinValueOfNumbericUpDown;
			nupFirstX.Maximum = MaxValueOfNumericUpDown;
			nupFirstY.Minimum = MinValueOfNumbericUpDown;
			nupFirstY.Maximum = MaxValueOfNumericUpDown;

			nupSecondX.Minimum = MinValueOfNumbericUpDown;
			nupSecondX.Maximum = MaxValueOfNumericUpDown;
			nupSecondY.Minimum = MinValueOfNumbericUpDown;
			nupSecondY.Maximum = MaxValueOfNumericUpDown;

			image = new Bitmap(pictureBoxGrid.Width, pictureBoxGrid.Height, PixelFormat.Format32bppRgb);
			pen = new Pen(Color.Gray, 1);

			Graphics.FromImage(image).Clear(Color.White);
			pictureBoxGrid.BackgroundImage = image;

			DrawGrid();
			DrawCoordinateSystem();
			DrawLabels();

			pictureBoxGrid.Invalidate();
		}

		private void DrawGrid()
		{
			pen.Color = Color.Black;
			pen.Width = 1;

			for (int i = 0; i < pictureBoxGrid.Height; i++)
			{
				// Vertical
				Graphics.FromImage(image).DrawLine(pen, i * CellSize, 0, i * CellSize, NumOfCells * CellSize);

				// Horizontal
				Graphics.FromImage(image).DrawLine(pen, 0, i * CellSize, NumOfCells * CellSize, i * CellSize);
			}
		}

		private void DrawCoordinateSystem()
		{
			pen.Color = Color.Black;
			pen.Width = 3;

			// Vertical
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width / 2, 0, pictureBoxGrid.Width / 2, pictureBoxGrid.Height);

			// Horizontal
			Graphics.FromImage(image).DrawLine(pen, 0, pictureBoxGrid.Height / 2, pictureBoxGrid.Width, pictureBoxGrid.Height / 2);

			// Arrows
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width / 2, 0, pictureBoxGrid.Width / 2 - BottomSpaceFromCoordinateLine, BottomSpaceFromCoordinateLine);
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width / 2, 0, pictureBoxGrid.Width / 2 + BottomSpaceFromCoordinateLine, BottomSpaceFromCoordinateLine);

			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width, pictureBoxGrid.Height / 2, pictureBoxGrid.Width - BottomSpaceFromCoordinateLine, pictureBoxGrid.Height / 2 - BottomSpaceFromCoordinateLine);
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width, pictureBoxGrid.Height / 2, pictureBoxGrid.Width - BottomSpaceFromCoordinateLine, pictureBoxGrid.Height / 2 + BottomSpaceFromCoordinateLine);
		}

		private void DrawLabels()
		{
			MaxValueOfCoordinate = Convert.ToInt32(Math.Ceiling(pictureBoxGrid.Height / 2.0 / CellSpace));
			int number = pictureBoxGrid.Height / 2 - CellSpace - Offset;

			for (int i = 1; i < MaxValueOfCoordinate; i++)
			{
				Graphics.FromImage(image).DrawString($"{i}", new Font(Font, FontStyle.Italic), Brushes.Black, pictureBoxGrid.Width / 2 - UpUpSpaceFromCoordinateLine, number);
				Graphics.FromImage(image).DrawString($"{-i}", new Font(Font, FontStyle.Italic), Brushes.Black, number, pictureBoxGrid.Height / 2 + BottomSpaceFromCoordinateLine);
				number -= CellSpace;
			}

			number = pictureBoxGrid.Width / 2 + (CellSpace - Offset);

			for (int i = 1; i < MaxValueOfCoordinate; i++)
			{
				Graphics.FromImage(image).DrawString($"{i}", new Font(Font, FontStyle.Italic), Brushes.Black, number, pictureBoxGrid.Height / 2 + BottomSpaceFromCoordinateLine);
				Graphics.FromImage(image).DrawString($"{-i}", new Font(Font, FontStyle.Italic), Brushes.Black, pictureBoxGrid.Width / 2 + BottomSpaceFromCoordinateLine, number);
				number += CellSpace;
			}
		}

		private void DrawGridInsideSquare(int firstX, int secondX, int firstY, int secondY)
		{
			pen = new Pen(Color.Black, 1);

			for (int i = firstX + CellSize; i < secondX; i += CellSize)
			{
				Graphics.FromImage(image).DrawLine(pen, i, firstY, i, secondY);
			}

			for (int i = firstY + CellSize; i < secondY; i += CellSize)
			{
				Graphics.FromImage(image).DrawLine(pen, firstX, i, secondX, i);
			}
		}

		private void DrawCircumcircleBySquare()
		{
			int firstX = Convert.ToInt32(nupFirstX.Value);
			int firstY = Convert.ToInt32(nupFirstY.Value);

			int secondX = Convert.ToInt32(nupSecondX.Value);
			int secondY = Convert.ToInt32(nupSecondY.Value);

			string errorMessage = GetErrorMessage(firstX, firstY, secondX, secondY);

			if (errorMessage != string.Empty)
			{
				MessageBox.Show(errorMessage, "Невірні координати", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}

			if (firstY >= 0)
			{
				firstY = pictureBoxGrid.Height / 2 - firstY * CellSpace;
			}
			else
			{
				firstY = Math.Abs(firstY);
				firstY = pictureBoxGrid.Height / 2 + firstY * CellSpace;
			}

			if (firstX >= 0)
			{
				firstX = pictureBoxGrid.Width / 2 + firstX * CellSpace;
			}
			else
			{
				firstX = Math.Abs(firstX);
				firstX = pictureBoxGrid.Width / 2 - firstX * CellSpace;
			}

			if (secondY >= 0)
			{
				secondY = pictureBoxGrid.Height / 2 - secondY * CellSpace;
			}
			else
			{
				secondY = Math.Abs(secondY);
				secondY = pictureBoxGrid.Height / 2 + secondY * CellSpace;
			}

			if (secondX >= 0)
			{
				secondX = pictureBoxGrid.Width / 2 + secondX * CellSpace;
			}
			else
			{
				secondX = Math.Abs(secondX);
				secondX = pictureBoxGrid.Width / 2 - secondX * CellSpace;
			}

			int diameter = GetDiameter(secondX, firstX);

			if (secondX - firstX == secondY - firstY)
			{
				pen = new Pen(cdCircleColor.Color, 1);
				Graphics.FromImage(image).DrawEllipse(pen, new Rectangle(firstX - diameter, firstY - diameter, secondX - firstX + diameter * 2, secondY - firstY + diameter * 2));
				Brush brush = new SolidBrush(cdCircleColor.Color);
				Graphics.FromImage(image).FillEllipse(brush, new Rectangle(firstX - diameter, firstY - diameter, secondX - firstX + diameter * 2, secondY - firstY + diameter * 2));

				brush = new SolidBrush(Color.White);
				Graphics.FromImage(image).FillRectangle(brush, new Rectangle(firstX, firstY, secondX - firstX, secondY - firstY));
				pen = new Pen(cdSquareColor.Color, 1);
				Graphics.FromImage(image).DrawRectangle(pen, new Rectangle(firstX, firstY, secondX - firstX, secondY - firstY));

				DrawGridInsideSquare(firstX, secondX, firstY, secondY);
				DrawCoordinateSystem();
				DrawLabels();

				pictureBoxGrid.Invalidate();
			}
			else
			{
				MessageBox.Show("Всі сторони мають бути рівними. Будь ласка, задайте коректні вершини", "Невірні координати", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private int GetDiameter(int secondX, int firstX) => GetOffsetForAngles(GetPerimeter(secondX - firstX) / CellSize);

		private int GetPerimeter(int x) => x * NumberOfAngles;

		private int GetOffsetForAngles(int diameter) => diameter + (diameter > 140 ? 6 : diameter > 100 ? 4 : diameter > 40 ? 2 : 0);

		private void btnAddSquare_Click(object sender, EventArgs e)
		{
			DrawCircumcircleBySquare();
		}

		private string GetErrorMessage(int firstX, int firstY, int secondX, int secondY)
		{
			if (secondX - firstX < 0 || secondY - firstY < 0)
			{
				return "Квадрат виходить за межі координатної площини";
			}

			if (firstX == MinValueOfNumbericUpDown && firstY == MinValueOfNumbericUpDown)
			{
				return $"Верхня ліва вершина повинна бути меншою за ({firstX}, {firstY})";
			}

			if (secondX <= firstX && secondY <= firstY)
			{
				return $"Нижня права вершина повинна бути більшою за ({firstX}, {firstY})";
			}

			return string.Empty;
		}

		private void btnSquareColor_Click(object sender, EventArgs e)
		{
			if (cdSquareColor.ShowDialog() == DialogResult.OK)
			{
				btnSquareColor.ForeColor = cdSquareColor.Color;
			}
		}

		private void btnCircleColor_Click(object sender, EventArgs e)
		{
			if (cdCircleColor.ShowDialog() == DialogResult.OK)
			{
				btnCircleColor.ForeColor = cdCircleColor.Color;
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Initialize();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			CellSpace = trackBar.Value * CellSize;

			Initialize();
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			
			stringBuilder.AppendLine("Програма забезпечує побудову квадратів за заданими координатами " +
			                         "двох вершин (верхньої та нижньої правої) із автоматичною побудовою " +
			                         "описаних кіл навколо квадратів. Також забезпечено можливість вибору " +
			                         "кольору межі квадратів та заливки кіл." + Environment.NewLine);

			stringBuilder.AppendLine("Автор: Качмар Роман");

			MessageBox.Show(stringBuilder.ToString(), "Довідка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}