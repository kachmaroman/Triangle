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
		private const int CellSpace = 40;

		private Bitmap image;
		private Pen pen;

		public Form1()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{
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
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width / 2, 0, pictureBoxGrid.Width / 2 - 10, 10);
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width / 2, 0, pictureBoxGrid.Width / 2 + 10, 10);

			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width, pictureBoxGrid.Height / 2, pictureBoxGrid.Width - 10, pictureBoxGrid.Height / 2 - 10);
			Graphics.FromImage(image).DrawLine(pen, pictureBoxGrid.Width, pictureBoxGrid.Height / 2, pictureBoxGrid.Width - 10, pictureBoxGrid.Height / 2 + 10);
		}

		private void DrawLabels()
		{
			int maxNum = 10;
			int number = pictureBoxGrid.Height / 2 - 45;

			for (int i = 1; i < maxNum; i++)
			{
				Graphics.FromImage(image).DrawString($"{i}", new Font(Font, FontStyle.Italic), Brushes.Black, pictureBoxGrid.Width / 2 - 25, number);
				Graphics.FromImage(image).DrawString($"{-i}", new Font(Font, FontStyle.Italic), Brushes.Black, number, pictureBoxGrid.Height / 2 + 10);
				number -= 40;
			}

			number = pictureBoxGrid.Width / 2 + 30;

			for (int i = 1; i < maxNum; i++)
			{
				Graphics.FromImage(image).DrawString($"{i}", new Font(Font, FontStyle.Italic), Brushes.Black, number, pictureBoxGrid.Height / 2 + 10);
				Graphics.FromImage(image).DrawString($"{-i}", new Font(Font, FontStyle.Italic), Brushes.Black, pictureBoxGrid.Width / 2 + 10, number);
				number += 40;
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
			int firstY = Convert.ToInt32(nupFirstY.Value);
			int firstX = Convert.ToInt32(nupFirstX.Value);

			int secondY = Convert.ToInt32(nupSecondY.Value);
			int secondX = Convert.ToInt32(nupSecondX.Value);

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

			int diameter = (secondX - firstX) * 4 / CellSize;

			diameter += diameter > 140 ? 6 : diameter > 100 ? 4 : diameter > 40 ? 2 : 0;

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
		}

		private void btnAddSquare_Click(object sender, EventArgs e)
		{
			DrawCircumcircleBySquare();
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
	}
}