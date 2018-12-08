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

		public Form1()
		{
			InitializeComponent();

			Bitmap image = new Bitmap(pictureBoxGrid.Width, pictureBoxGrid.Height, PixelFormat.Format32bppRgb);
			Pen pen = new Pen(Color.Gray, 1);

			DrawGrid(image, pen);

			pen.Color = Color.Black;
			pen.Width = 3;

			DrawCoordinateSystem(image, pen);
			DrawLabels(image);
			
			pictureBoxGrid.Invalidate();
		}

		private void DrawGrid(Bitmap image, Pen pen)
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

		private void DrawCoordinateSystem(Bitmap image, Pen pen)
		{
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

			//Graphics.FromImage(image).DrawRectangle(pen, new Rectangle(760, 240, 50, 50));
		}
	}
}