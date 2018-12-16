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

		private static int x = -4;
		private static int y = 4;
		private static int angle = 90;


		private double[,] translate = {
										{ 1, 0, x },
										{ 0, 1, y },
										{ 0, 0, 1 }
									  };

		private double[,] scale = {
									{ x, 0, 0 },
									{ 0, y, 0 },
									{ 0, 0, 1 }
								  };

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
			DrawDefaultTriangle();

			pictureBoxGrid.Invalidate();
		}


		private void DrawDefaultTriangle()
		{
			int firstX = GetByCoordinateX(0);
			int secondX = GetByCoordinateX(-5);
			int thirdX = GetByCoordinateX(5);

			int firstY = GetByCoordinateY(5);
			int secondY = GetByCoordinateY(-5);
			int thirdY = GetByCoordinateY(-5);

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
			int firstX = Convert.ToInt32(nupFirstX.Value);
			int firstY = Convert.ToInt32(nupFirstY.Value);

			int secondX = Convert.ToInt32(nupSecondX.Value);
			int secondY = Convert.ToInt32(nupSecondY.Value);

			double[,] triangleMatrix = new double[2, 3] { { 0, -5, 5 }, { 5, -5, -5 } };

			double[,] firstTranslate =
			{
				{ 1, 0, firstX },
				{ 0, 1, firstY },
				{ 0, 0, 1 }
			};

			double[,] firstScale = {
				{ secondX, 0, 0 },
				{ 0, secondY, 0 },
				{ 0, 0, 1 }
			};

			var result = MatrixMult(firstTranslate, firstScale);

			double[,] resultMatrix = result;

			//double[,] secondTranslate = 
			//{
			//	{ 1, 0, secondX },
			//	{ 0, 1, secondY },
			//	{ 0, 0, 1 }
			//};

			//double[,] secondScale = {
			//	{ secondX, 0, 0 },
			//	{ 0, secondY, 0 },
			//	{ 0, 0, 1 }
			//};

			//resultMatrix = AffinaMult(resultMatrix, secondScale);

			firstX = GetByCoordinateX(resultMatrix[0, 0]);
			firstY = GetByCoordinateY(resultMatrix[1, 0]);

			secondX = GetByCoordinateX(resultMatrix[0, 1]);
			secondY = GetByCoordinateY(resultMatrix[1, 1]);

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

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			CellSpace = trackBar.Value * CellSize;

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