    public partial class Form1 : Form
    {
        private uint WM_PAINT = 0x0F;
        public Form1()
        {
            InitializeComponent();
            hatchedPen = (Pen)SystemPens.ControlDarkDark.Clone();
            hatchedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                WndProcHooker.HookWndProc(ctrl, new WndProcHooker.WndProcCallback(HandlePaint), WM_PAINT);
            }
        }
        private int HandlePaint(IntPtr hwnd, uint msg, uint wParam, int lParam, ref bool handled)
        {
            Debug.WriteLine("WM_PAINT");
            handled = false;
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                var bounds = Control.FromHandle(hwnd).Bounds;
                bounds = Rectangle.Inflate(bounds, 4, 4);
                bounds.X--;
                bounds.Y--;
                g.DrawRectangle(hatchedPen, bounds);
                foreach(Point pt in new Point[]
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
                    g.FillRectangle(SystemBrushes.ControlDarkDark, r);
                }
            }
            return 0;
        }
        private Pen hatchedPen;
    }
