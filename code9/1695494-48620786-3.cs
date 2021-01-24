    private List<Point> circleCoordinates = new List<Point>();
    
    public Form1()
    {
      InitializeComponent();
    }
    public void addcoordinate(int r1, int r2)
    {
      this.circleCoordinates.Add(new Point(r1, r2));
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      // linedrawing goes here
      foreach (Point point in this.circleCoordinates)
      {
        e.Graphics.DrawEllipse(Pens.Black, new Rectangle(point, new Size(10, 10)));
      }
      base.OnPaint(e);
    }
    private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      for (int i = this.circleCoordinates.Count() - 1; i >= 0; i--)
      {
        Rectangle ellipseRectangle = new Rectangle(this.circleCoordinates[i].X - 5, this.circleCoordinates[i].Y - 5, 10, 10)
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(ellipseRectangle);
        if(path.IsVisible(e.Location))
        {
          this.circleCoordinates.RemoveAt(i);
        }
        //invalidate form to trigger repainting
        this.Invalidate();
      }
