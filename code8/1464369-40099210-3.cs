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
            // Clear any existing grab handles
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                foreach (Control ctrl in Controls)
                {
                    var rect = GetGrabBounds(ctrl);
                    g.FillRectangle(SystemBrushes.ButtonFace, rect);
                }
            }
            // Need to draw grab handles?
            if (ActiveControl != null && e.ClipRectangle.IntersectsWith(GetGrabBounds(ActiveControl)))
            {
                DrawGrabHandles(ActiveControl);
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
                    g.FillRectangle(SystemBrushes.ButtonFace, r);
                    g.DrawRectangle(SystemPens.ControlDarkDark, r);
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
