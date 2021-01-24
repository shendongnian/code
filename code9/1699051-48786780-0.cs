    protected override void OnPaint(PaintEventArgs e)
    {
        if (comboBox_Shape.SelectedIndex != -1 && comboBox_Colour.SelectedIndex != -1)
        {
            Color c = (Color)comboBox_Colour.SelectedItem;
            SolidBrush sb = new SolidBrush(c);
            if (comboBox_Shape.Text == "Circle")
            {
                e.Graphics.FillEllipse(sb, new Rectangle(105, 120, 64, 64));
            }
            else if (comboBox_Shape.Text == "Rectangle")
            {
                e.Graphics.FillRectangle(sb, new Rectangle(105, 120, 75, 50));
            }
            else if (comboBox_Shape.Text == "Triangle")
            {
                Point[] points = { new Point(140, 110), new Point(230, 190), new Point(50, 190) };
                e.Graphics.FillPolygon(sb, points);
            }
        }
    }
