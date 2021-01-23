    ShapesList Shapes;
    private void Form3_Load(object sender, EventArgs e)
    {
        Shapes = new ShapesList();
        Shapes.Add(new RectangleShape() { Rectangle = new Rectangle(0, 0, 100, 100), 
            Color = Color.Green });
        Shapes.Add(new RectangleShape() { Rectangle = new Rectangle(50, 50, 100, 100), 
            Color = Color.Blue });
        Shapes.Add(new LineShape() { Point1 = new Point(0, 0), Point2 = new Point(150, 150), 
            Color = Color.Red });
        this.panel1.Invalidate();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Shapes.Save(@"d:\shapes.bin");
        Shapes.Clear();
        this.panel1.Invalidate();
        MessageBox.Show("Shapes saved successfully.");
        Shapes.Load(@"d:\shapes.bin");
        this.panel1.Invalidate();
        MessageBox.Show("Shapes loaded successfully.");
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        Shapes.Draw(e.Graphics);
    }
