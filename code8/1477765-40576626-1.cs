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
        this.comboBox1.DataSource = Shapes;
    }
    private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
        this.panel1.Invalidate();
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.propertyGrid1.SelectedObject = this.comboBox1.SelectedItem;
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        Shapes.Draw(e.Graphics);
    }
