    public partial class Resizer : Control
    {
        public Resizer()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(12, 12);
        }
        public Control control { get; set; }
        Point mDown = Point.Empty;
        public Resizer(Control ctl) 
        {
            InitializeComponent();
            control = ctl;
            Size = new System.Drawing.Size(12, 12);
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (control != null)
            {
                
                BackColor = Color.DarkOrange;
                Location = new Point(control.Width - Size.Width, control.Height - Size.Height);
                Parent = control;
                BringToFront();
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mDown = e.Location;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Hide();
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                Left += -(mDown.X - e.X);
                Top += -(mDown.Y - e.Y);
                control.Size = new Size(Right, Bottom);
            }
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
