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

			image = new Bitmap(pictureBoxGrid.Width, pictureBoxGrid.Height, PixelFormat.Format32bppRgb);
			pen = new Pen(Color.Gray, 1);

			DrawGrid();
			DrawCoordinateSystem();
			DrawLabels(image);

			pictureBoxGrid.Invalidate();
		}

		private void DrawGrid()
		{
			Graphics.FromImage(image).Clear(Color.White);
			pictureBoxGrid.BackgroundImage = image;

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

		private void DrawLabels(Bitmap image)
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

		private void DrawSquare()
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

			int radius = (secondX - firstX) * 4 / 20;

			if (secondX - firstX == secondY - firstY)
			{
				Graphics.FromImage(image).DrawLine(pen, firstX, firstY, secondX, secondY);
				Graphics.FromImage(image).DrawRectangle(pen, new Rectangle(firstX, firstY, secondX - firstX, secondY - firstY));
				Graphics.FromImage(image).DrawEllipse(pen, new Rectangle(firstX - radius, firstY - radius, secondX - firstX + radius * 2, secondY - firstY + radius * 2));
				pictureBoxGrid.Invalidate();
			}
		}

		private void btnAddSquare_Click(object sender, EventArgs e)
		{


			DrawSquare();
		}
	}
}