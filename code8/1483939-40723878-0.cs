    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
    	public partial class Form1 : Form
    	{
    		private struct LineSegment
    		{
    			private PointF _a, _b;
    
    			public PointF A { get { return _a; } }
    			public PointF B { get { return _b; } }
    
    			public LineSegment(PointF a, PointF b)
    			{
    				_a = a; _b = b;
    			}
    
    			public float GetLengthSquared()
    			{
    				var dx = _a.X - _b.X;
    				var dy = _a.Y - _b.Y;
    				return dx * dx + dy * dy;
    			}
    
    			public bool RectContains(PointF a)
    			{
    				var x = a.X;
    				var y = a.Y;
    				var x1 = _a.X;
    				var y1 = _a.Y;
    				var x2 = _b.X;
    				var y2 = _b.Y;
    				return (x1 < x2 ? x1 <= x && x2 >= x : x2 <= x && x1 >= x) && (y1 < y2 ? y1 <= y && y2 >= y : y2 <= y && y1 >= y);
    			}
    
    			public bool ExtendToIntersectWith(LineSegment b)
    			{
    				var x1 = _a.X;
    				var y1 = _a.Y;
    				var x2 = _b.X;
    				var y2 = _b.Y;
    
    				var x3 = b._a.X;
    				var y3 = b._a.Y;
    				var x4 = b._b.X;
    				var y4 = b._b.Y;
    
    				var a1 = y2 - y1;
    				var b1 = x1 - x2;
    				var c1 = x1 * y2 - x2 * y1;
    
    				var a2 = y4 - y3;
    				var b2 = x3 - x4;
    				var c2 = x3 * y4 - x4 * y3;
    
    				var d = a1 * b2 - b1 * a2;
    				if (d == 0)
    					return false;
    
    				var x = (c1 * b2 - b1 * c2) / d;
    				var y = (a1 * c2 - c1 * a2) / d;
    				var p = new PointF(x, y);
    
    				if (b.RectContains(p) && !RectContains(p))
    				{
    					if (new LineSegment(_a, p).GetLengthSquared() < new LineSegment(_b, p).GetLengthSquared())
    						_a = p;
    					else
    						_b = p;
    					return true;
    				}
    
    				return false;
    			}
    		}
    
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void Form1_Paint(object sender, PaintEventArgs e)
    		{
    			PointF[] curvePoints =
    			{
    				/*
    				new PointF(50.0F,  50.0F),
    				new PointF(100.0F,  25.0F),
    				new PointF(200.0F,   5.0F),
    				new PointF(250.0F,  50.0F),
    				new PointF(300.0F, 100.0F),
    				new PointF(350.0F, 200.0F),
    				new PointF(250.0F, 250.0F)
    				*/
    				new PointF(30F,  10F),
    				new PointF(60F,  10F),
    				new PointF(60F,  20F),
    				new PointF(90F,  20F),
    				new PointF(90F,  60F),
    				new PointF(10F,  60F),
    				new PointF(10F,  40F),
    				new PointF(30F,  40F),
    			};
    			int n = curvePoints.Length;
    			LineSegment[] lineSegments = new LineSegment[n];
    			int i = 0;
    			for (; i < n - 1; ++i)
    				lineSegments[i] = new LineSegment(curvePoints[i], curvePoints[i + 1]);
    			lineSegments[i] = new LineSegment(curvePoints[i], curvePoints[0]);
    			for (i = 0; i < n; ++i)
    				for (int j = 0; j < n; ++j)
    					lineSegments[i].ExtendToIntersectWith(lineSegments[j]);
    			for (i = 0; i < n; ++i)
    			{
    				var lineSegment = lineSegments[i];
    				e.Graphics.DrawLine(Pens.Black, lineSegment.A, lineSegment.B);
    			}
    			//e.Graphics.DrawPolygon(Pens.Black, curvePoints);
    		}
    	}
    }
