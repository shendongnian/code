	using System.Drawing;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public class PerspectiveGrid : Control
		{
			private Perspective _perspective;
			public Perspective Perspective
			{
				get { return _perspective; }
				set
				{
					_perspective = value; 
					Invalidate();
				}
			}
			public PerspectiveGrid()
			{
				Perspective = new Perspective
				{
					X_shift = 100,
					Y_shift = 10,
					X_x = -0.2f,
					X_y = 1.0f,
					X_z = 0.0f,
					Y_x = 0.2f,
					Y_y = 0.0f,
					Y_z = 1.0f,
				};
			}
			/// <summary>
			/// Paints a Grid at Z = 400 and two Sensors
			/// </summary>
			protected override void OnPaint(PaintEventArgs e)
			{
				DrawGrid(10,40,400,e.Graphics);
				DrawSensor(new Point3D(80, 120, 400), new Point3D(80, 120, 200), e.Graphics);
				DrawSensor(new Point3D(240, 240, 400), new Point3D(240, 240, 120), e.Graphics);
			}
			/// <summary>
			/// Draws a sensor at the specified position(s)
			/// </summary>
			private void DrawSensor(Point3D from, Point3D to, Graphics gr)
			{
				DrawLine(gr, Pens.Black, from, to);
				DrawSphere(gr, Pens.Black, Brushes.Orange, to, 6);
			}
			/// <summary>
			/// Draws a sphere as a Circle at the specified position
			/// </summary>
			private void DrawSphere(Graphics gr, Pen outline, Brush fill, Point3D center, float radius)
			{
				PointF center2D = Project(center);
				gr.FillEllipse(fill, center2D.X - radius, center2D.Y - radius, radius * 2, radius * 2);
				gr.DrawEllipse(outline, center2D.X - radius, center2D.Y - radius, radius * 2, radius * 2);
			}
			/// <summary>
			/// Draws the grid at the specified depth
			/// </summary>
			private void DrawGrid(int numOfCells, int cellSize, int depth, Graphics gr)
			{
				Pen p = Pens.SteelBlue;
				for (int i = 0; i <= numOfCells; i++)
				{
					// Vertical
					DrawLine(gr, p, new Point3D(i * cellSize, 0 , depth), new Point3D(i * cellSize, numOfCells * cellSize, depth));
					// Horizontal
					DrawLine(gr, p, new Point3D(0, i * cellSize, depth), new Point3D(numOfCells * cellSize, i * cellSize, depth));
				}
			}
			/// <summary>
			/// Draws a line from one 3DPoint to another
			/// </summary>
			private void DrawLine(Graphics graphics, Pen pen, Point3D p1, Point3D p2)
			{
				PointF pointFrom = Project(p1);
				PointF pointTo = Project(p2);
				graphics.DrawLine(pen, pointFrom, pointTo);
			}
			/// <summary>
			/// Projects a Point3D to a PointF
			/// </summary>
			private PointF Project(Point3D p)
			{
				return Perspective.Project(p);
			}
		}
	}
