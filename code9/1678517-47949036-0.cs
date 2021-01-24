    public Form1()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(400, 273);
        this.Resize += new System.EventHandler(this.Form1_Resize);
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        var task = AnimateLine();
    }
    private readonly Point _lineStart = new Point(12, 30);
    private readonly Point _lineFinalEnd = new Point(300, 60);
    private const int _animateSteps = 300;
    private Point _lineCurrentEnd;
    private bool _drawArrow;
    private async Task AnimateLine()
    {
        Size size = new Size(_lineFinalEnd) - new Size(_lineStart);
        for (int i = 1; i <= _animateSteps; i++)
        {
            await Task.Delay(2);
            Size currentSize = new Size(
                size.Width * i / _animateSteps, size.Height * i / _animateSteps);
            _lineCurrentEnd = _lineStart + currentSize;
            Invalidate();
        }
        _drawArrow = true;
        Invalidate();
    }
    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using (Pen p = new Pen(Color.Black, 5))
        {
            p.StartCap = LineCap.Round;
            p.EndCap = _drawArrow ? LineCap.ArrowAnchor : p.EndCap;
            g.DrawLine(p, _lineStart, _lineCurrentEnd);
        }
    }
