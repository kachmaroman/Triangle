using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
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

		private Bitmap image;
		private Pen pen;

		private double[,] defaultTriangle = new double[3, 3] { {1, 4, 1}, {1, 1, 1}, {4, 1, 1} };
		private double[,] currentTriangle;

		private double defaultAverageX = 0;
		private double defaultAverageY = 0;

		public Form1()
		{
			InitializeComponent();

			Initialize();

			currentTriangle = defaultTriangle;

			DrawDefaultTriangle();

			defaultAverageX = GetAverageXOfTriangle(currentTriangle);
			defaultAverageY = GetAverageYOfTriangle(currentTriangle);
		}

		private void Initialize()
		{
			MaxValueOfCoordinate = Convert.ToInt32(Math.Ceiling(pictureBoxGrid.Height / 2.0 / CellSpace));

			image = new Bitmap(pictureBoxGrid.Width, pictureBoxGrid.Height, PixelFormat.Format32bppRgb);
			pen = new Pen(Color.Gray, 1);

			Graphics.FromImage(image).Clear(Color.White);
			pictureBoxGrid.BackgroundImage = image;

			DrawGrid();
			DrawCoordinateSystem();
			DrawLabels();
			
			pictureBoxGrid.Invalidate();
		}

		private void DrawDefaultTriangle()
		{
			float firstX = GetByCoordinateX(defaultTriangle[0, 0]);
			float firstY = GetByCoordinateY(defaultTriangle[0, 1]);


			float secondX = GetByCoordinateX(defaultTriangle[1, 0]);
			float secondY = GetByCoordinateY(defaultTriangle[1, 1]);

			float thirdX = GetByCoordinateX(defaultTriangle[2, 0]);
			float thirdY = GetByCoordinateY(defaultTriangle[2, 1]);

			pen.Color = Color.Black;
			pen.Width = 3;

			PointF[] points = new PointF[3];
			points[0] = new PointF(firstX, firstY);
			points[1] = new PointF(secondX, secondY);
			points[2] = new PointF(thirdX, thirdY);

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

		private float GetByCoordinateY(double value)
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

			return Convert.ToSingle(value);
		}

		private float GetByCoordinateX(double value)
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

			return Convert.ToSingle(value);
		}

		private void DrawTriangle()
		{
			int x = Convert.ToInt32(nupX.Value);
			int y = Convert.ToInt32(nupY.Value);

			if (x == 0 || y == 0)
			{
				MessageBox.Show("Неможливо збільшити трикутник в нуль раз!", "Невірно задані дані", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}

			double[,] matrix = MoveToCenter(defaultTriangle);
			matrix = Rotate(matrix);
			matrix = MoveToDefaultPosition(matrix);
			matrix = Scale(matrix);
			currentTriangle = matrix;
			DrawCurrentTriangle(matrix);
		}

		private void btnAddSquare_Click(object sender, EventArgs e)
		{
			DrawTriangle();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Initialize();
			DrawDefaultTriangle();
		}

		private double[,] AffinaMult(double[,] triangleMatrix, double[,] affinMaxtix)
		{
			double[,] resultMatrix = new double[3, 3];

			for (int i = 0; i <= triangleMatrix.Rank; i++)
			{
				for (int j = 0; j <= triangleMatrix.Rank; j++)
				{
					for (int k = 0; k <= triangleMatrix.Rank; k++)
					{
						resultMatrix[i, j] += triangleMatrix[i, k] * affinMaxtix[k, j];
					}
				}
			}

			return resultMatrix;
		}

		private double GetAverageXOfTriangle(double[,] triangle)
		{
			double sum = triangle[0, 0] + triangle[1, 0] + triangle[2, 0];
			return sum / 3.0;
		}

		private double GetAverageYOfTriangle(double[,] triangle)
		{
			double sum = triangle[0, 1] + triangle[1, 1] + triangle[2, 1];
			return sum / 3.0;
		}

		private void nupDegree_ValueChanged(object sender, EventArgs e)
		{
			//double[,] matrix = MoveToCenter(currentTriangle);
			//matrix = Rotate(matrix);
			//matrix = MoveToDefaultPosition(matrix);
			////matrix = Scale(matrix);
			//currentTriangle = matrix;
			//DrawCurrentTriangle(matrix);
		}

		private double[,] MoveToCenter(double[,] matrix)
		{
			double averageX = GetAverageXOfTriangle(matrix);
			double averageY = GetAverageYOfTriangle(matrix);

			double[,] translate =
			{
				{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ -averageX, -averageY, 1 }
			};

			return AffinaMult(matrix, translate);
		}

		private double[,] MoveToDefaultPosition(double[,] matrix)
		{
			double[,] translate =
			{
				{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ defaultAverageX, defaultAverageY, 1 }
			};

			return AffinaMult(matrix, translate);
		}

		private double[,] Rotate(double[,] matrix)
		{
			double angle = Convert.ToDouble(nupDegree.Value) * Math.PI / 180;

			double[,] rotate = {
				{   Math.Cos(angle), -Math.Sin(angle), 0 },
				{   Math.Sin(angle),  Math.Cos(angle), 0 },
				{   0,                0,               1 }
			};

			return AffinaMult(matrix, rotate);
		}

		private double[,] Scale(double[,] matrix)
		{
			int x = Convert.ToInt32(nupX.Value);
			int y = Convert.ToInt32(nupY.Value);

			double[,] scale = {
				{ x, 0, 0 },
				{ 0, y, 0 },
				{ 0, 0,  1 }
			};

			return AffinaMult(matrix, scale);

		}

		private void DrawCurrentTriangle(double[,] triangle)
		{
			float firstX = GetByCoordinateX(triangle[0, 0]);
			float firstY = GetByCoordinateY(triangle[0, 1]);

			float secondX = GetByCoordinateX(triangle[1, 0]);
			float secondY = GetByCoordinateY(triangle[1, 1]);

			float thirdX = GetByCoordinateX(triangle[2, 0]);
			float thirdY = GetByCoordinateY(triangle[2, 1]);

			if ((firstX < 0 || firstX > 800 ||
			     secondX < 0 || secondX > 800 ||
			     thirdX < 0 || thirdX > 800) ||
			    (firstY < 0 || firstY > 800 ||
			     secondY < 0 || secondY > 800 ||
			     thirdY < 0 || thirdY > 800))
			{
				MessageBox.Show("Трикутник виходить за межі координат!", "Невірні координати", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}

			PointF[] points = new PointF[3];
			points[0] = new PointF(firstX, firstY);
			points[1] = new PointF(secondX, secondY);
			points[2] = new PointF(thirdX, thirdY);

			Initialize();

			Graphics.FromImage(image).DrawPolygon(pen, points);
			pictureBoxGrid.BackgroundImage = image;

			pictureBoxGrid.Invalidate();
		}
	}
}