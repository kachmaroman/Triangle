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
		private const int CellSpace = 20;
		private const int Offset = 5;
		private const int UpUpSpaceFromCoordinateLine = 25;
		private const int BottomSpaceFromCoordinateLine = 10;


		private int MaxValueOfCoordinate;
		private int MaxValueOfNumericUpDown;
		private int MinValueOfNumbericUpDown;

		private Bitmap image;
		private Pen pen;

		private static double angle = 90 * Math.PI / 180;


		private double[,] rotate = {
										{  Math.Cos(angle), Math.Sin(angle), 0 },
										{ -Math.Sin(angle), Math.Cos(angle), 0 },
										{  0,               0,               1 }
								   };


		public Form1()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{
			MaxValueOfCoordinate = Convert.ToInt32(Math.Ceiling(pictureBoxGrid.Height / 2.0 / CellSpace));

			MaxValueOfNumericUpDown = MaxValueOfCoordinate - 1;
			MinValueOfNumbericUpDown = MaxValueOfNumericUpDown * -1;

			nupX.Minimum = MinValueOfNumbericUpDown;
			nupY.Minimum = MinValueOfNumbericUpDown;

			nupX.Maximum = MaxValueOfNumericUpDown;
			nupY.Maximum = MaxValueOfNumericUpDown;

			image = new Bitmap(pictureBoxGrid.Width, pictureBoxGrid.Height, PixelFormat.Format32bppRgb);
			pen = new Pen(Color.Gray, 1);

			Graphics.FromImage(image).Clear(Color.White);
			pictureBoxGrid.BackgroundImage = image;

			DrawGrid();
			DrawCoordinateSystem();
			DrawLabels();
			DrawDefaultTriangle();

			pictureBoxGrid.Invalidate();
		}


		private void DrawDefaultTriangle()
		{
			int firstX = GetByCoordinateX(0);
			int secondX = GetByCoordinateX(-5);
			int thirdX = GetByCoordinateX(5);

			int firstY = GetByCoordinateY(8);
			int secondY = GetByCoordinateY(2);
			int thirdY = GetByCoordinateY(2);

			pen.Color = Color.Black;
			pen.Width = 3;

			Point[] points = new Point[3];
			points[0] = new Point(firstX, firstY);
			points[1] = new Point(secondX, secondY);
			points[2] = new Point(thirdX, thirdY);

			Graphics.FromImage(image).DrawPolygon(pen, points);
			pictureBoxGrid.BackgroundImage = image;

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

		private int GetByCoordinateY(double value)
		{
			if (value >= 0)
			{
				value = pictureBoxGrid.Height / 2.0 - value * CellSpace;
			}
			else
			{
				value = Math.Abs(value);
				value = pictureBoxGrid.Height / 2.0 + value * CellSpace;
			}

			return Convert.ToInt32(value);
		}

		private int GetByCoordinateX(double value)
		{
			if (value >= 0)
			{
				value = pictureBoxGrid.Width / 2.0 + value * CellSpace;
			}
			else
			{
				value = Math.Abs(value);
				value = pictureBoxGrid.Width / 2.0 - value * CellSpace;
			}

			return Convert.ToInt32(value);
		}

		private void DrawTriangle()
		{
			int x = Convert.ToInt32(nupX.Value);
			int y = Convert.ToInt32(nupY.Value);

			double[,] triangleMatrix = new double[2, 3] { { 0, -5, 5 }, { 8, 2, 2 } };

			double[,] firstTranslate =
			{
				{ 1, 0, x },
				{ 0, 1, y },
				{ 0, 0, 1 }
			};

			double[,] firstScale = {
				{ x, 0, 0 },
				{ 0, y, 0 },
				{ 0, 0, 1 }
			};

			double[,] resultMatrix = AffinaMult(triangleMatrix, firstScale);
			resultMatrix = AffinaMult(resultMatrix, rotate);

			int firstX = GetByCoordinateX(resultMatrix[0, 0]);
			int firstY = GetByCoordinateY(resultMatrix[1, 0]);

			int secondX = GetByCoordinateX(resultMatrix[0, 1]);
			int secondY = GetByCoordinateY(resultMatrix[1, 1]);

			int thirdX = GetByCoordinateX(resultMatrix[0, 2]);
			int thirdY = GetByCoordinateY(resultMatrix[1, 2]);

			Point[] points = new Point[3];
			points[0] = new Point(firstX, firstY);
			points[1] = new Point(secondX, secondY);
			points[2] = new Point(thirdX, thirdY);

			Graphics.FromImage(image).DrawPolygon(pen, points);
			pictureBoxGrid.BackgroundImage = image;

			pictureBoxGrid.Invalidate();
		}

		private void btnAddSquare_Click(object sender, EventArgs e)
		{
			DrawTriangle();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Initialize();
		}

		private double[,] AffinaMult(double[,] triangleMatrix, double[,] affinMaxtix)
		{
			double[,] resultMatrix = new double[2, 3];

			for (int i = 0; i < triangleMatrix.Rank; i++)
			{
				for (int j = 0; j <= triangleMatrix.Rank; j++)
				{
					for (int k = 0; k <= triangleMatrix.Rank; k++)
					{
						resultMatrix[i, j] += triangleMatrix[i, j] * affinMaxtix[k, j];
					}
				}
			}

			return resultMatrix;
		}

		private double[,] MatrixMult(double[,] triangleMatrix, double[,] affinMaxtix)
		{
			double[,] resultMatrix = new double[3, 3];

			for (int i = 0; i <= triangleMatrix.Rank; i++)
			{
				for (int j = 0; j <= triangleMatrix.Rank; j++)
				{
					for (int k = 0; k <= triangleMatrix.Rank; k++)
					{
						resultMatrix[i, j] += triangleMatrix[i, j] * affinMaxtix[k, j];
					}
				}
			}

			return resultMatrix;
		}
	}
}