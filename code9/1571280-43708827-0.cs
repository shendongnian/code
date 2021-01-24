    public partial class SliderControl : Control
    {
        public event EventHandler ValueChanged;
        public int MinValue { get; set; } 
        public int MaxValue { get; set; }
        public int Value { get; set; }
        public SliderControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.OptimizedDoubleBuffer, true);
            this.MinValue=0;
            this.MaxValue=100;
            this.Value=50;
            this.Text="Value";
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetBoundsCore(Left, Top, Width, 32, BoundsSpecified.Height);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawRectangle(Pens.Black, 0, 0, Width-1, Height-16);
            using (var gp = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, Value*(Width-1)/MaxValue-1, Height-16);
                gp.AddRectangle(rect);
                using (var br = new LinearGradientBrush(rect, Color.SteelBlue, Color.LightBlue, LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillPath(br, gp);
                    pe.Graphics.DrawPath(Pens.DarkBlue, gp);
                }
            }
            var text = $"{this.Text} = {this.Value}";
            var sz = pe.Graphics.MeasureString(text, SystemFonts.SmallCaptionFont);
            pe.Graphics.DrawString(text, SystemFonts.SmallCaptionFont, Brushes.Black, Width/2-sz.Width/2, Height-16);
        }
        private void SetClickValue(Point click_point)
        {
            int x = (click_point.X+1)*MaxValue/Width;
            this.Value=x;
            this.Refresh();
            this.ValueChanged?.Invoke(this, new EventArgs());
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button==MouseButtons.Left)
            {
                SetClickValue(e.Location);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button==MouseButtons.Left)
            {
                SetClickValue(e.Location);
            }
        }
    }
