    public Form1()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;
        using (var brush = new LinearGradientBrush(this.ClientRectangle,
            Color.Transparent, Color.Transparent, LinearGradientMode.Vertical))
        {
            var b = new ColorBlend();
            b.Positions = new[] { 0, 3 / 10f, 1 };
            b.Colors = new[] { Color.WhiteSmoke, Color.LightSteelBlue, Color.LightSteelBlue };
            brush.InterpolationColors = b;
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }
