    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hatchedPen = (Pen)SystemPens.ControlDarkDark.Clone();
            hatchedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Look for any controls that need to be redrawn
            foreach (Control ctrl in Controls)
            {
                if (e.ClipRectangle.IntersectsWith(GetGrabBounds(ctrl)))
                {
                    Debug.WriteLine("Redraw");
                    DrawGrabHandles(ctrl);
                }
            }
        }
        private void DrawGrabHandles(Control ctrl)
        {
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                Rectangle bounds = GetGrabRect(ctrl);
                g.DrawRectangle(hatchedPen, bounds);
                foreach (Point pt in new Point[]
                    {
                        new Point(bounds.Left, bounds.Top),
                        new Point(bounds.Left + bounds.Width / 2, bounds.Top),
                        new Point(bounds.Right, bounds.Top),
                        new Point(bounds.Left, bounds.Top + bounds.Height / 2),
                        new Point(bounds.Right, bounds.Top + bounds.Height / 2),
                        new Point(bounds.Left, bounds.Bottom),
                        new Point(bounds.Left + bounds.Width / 2, bounds.Bottom),
                        new Point(bounds.Right, bounds.Bottom),
                    })
                {
                    Rectangle r = new Rectangle(pt, new Size(5, 5));
                    r.X = r.X - 2;
                    r.Y = r.Y - 2;
                    if (this.ActiveControl == ctrl)
                    {
                        g.FillRectangle(SystemBrushes.ButtonFace, r);
                        g.DrawRectangle(SystemPens.ControlDarkDark, r);
                    }
                    else
                    {
                        g.FillRectangle(SystemBrushes.ControlDarkDark, r);
                    }
                }
            }
        }
        private static Rectangle GetGrabRect(Control ctrl)
        {
            var result = ctrl.Bounds;
            result = Rectangle.Inflate(result, 4, 4);
            result.X--;
            result.Y--;
            return result;
        }
        private static Rectangle GetGrabBounds(Control ctrl)
        {
            var result = GetGrabRect(ctrl);
            result.Inflate(4, 4);
            return result;
        }
        private Pen hatchedPen;
    }
