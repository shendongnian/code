    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication1
        {
    
        public class DrawingSurface : Panel
            {
            private const double snapLimit = 7.0D;
            private List<Point> snapPoints = new List<Point>();
            private Point cursorPos;
            private Point lastDrawnPos;
            private bool drawCursor;
    
            public DrawingSurface() : base()
                {
                this.BorderStyle = BorderStyle.Fixed3D;
                this.BackColor = Color.AliceBlue;
                this.DoubleBuffered = true;
                this.Cursor = Cursors.Cross;
                }
    
            protected override void OnMouseEnter(EventArgs e)
                {
                base.OnMouseEnter(e);
                System.Windows.Forms.Cursor.Hide();
                }
    
            protected override void OnMouseLeave(EventArgs e)
                {
                base.OnMouseLeave(e);
                System.Windows.Forms.Cursor.Show();
                this.drawCursor = false;
                this.Invalidate();
                }
    
            protected override void OnPaint(PaintEventArgs e)
                {
                base.OnPaint(e);
                foreach (Point dot in this.snapPoints)
                    {
                    e.Graphics.FillEllipse(Brushes.Red, dot.X - 1, dot.Y - 1, 2, 2);
                    }
                if (drawCursor)
                    {
                    Cursor cur = System.Windows.Forms.Cursor.Current;
                    Point pt = this.cursorPos;
                    pt.Offset(-cur.HotSpot.X, -cur.HotSpot.Y);
                    Rectangle target = new Rectangle(pt, cur.Size);
                    cur.Draw(e.Graphics, target);
                    this.lastDrawnPos = this.cursorPos;
                    }
    
                }
    
            protected override void OnMouseMove(MouseEventArgs e)
                {
                base.OnMouseMove(e);
                SetCursor(e.Location);
                }
    
            private void SetCursor(Point loc)
                {
                this.cursorPos = loc;
                foreach (Point pt in this.snapPoints)
                    {
                    double deltaX = loc.X - pt.X;
                    double deltaY = loc.Y - pt.Y;
                    double radius = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                    if (radius < snapLimit)
                        {
                        this.cursorPos = pt;
                        break;
                        }
                    }
                if (lastDrawnPos != this.cursorPos)
                    {
                    this.drawCursor = true;
                    this.Invalidate();
                    }
                }
    
            protected override void OnSizeChanged(EventArgs e)
                {
                base.OnSizeChanged(e);
                this.snapPoints.Clear();
                for (int y = 0; y <= this.ClientRectangle.Height; y += 50)
                    {
                    for (int x = 0; x <= this.ClientRectangle.Width; x += 50)
                        {
                        this.snapPoints.Add(new Point(x, y));
                        }
                    }
                }
            }
        }
