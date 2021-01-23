    [Serializable]
    public abstract class Shape
    {
        public abstract void Draw(Graphics g);
        public override string ToString() { return GetType().Name; }
    }
    [Serializable]
    public class LineShape : Shape
    {
        public LineShape(){ Color = Color.Blue; Width = 2; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public int Width { get; set; }
        public Color Color { get; set; }
        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(Color, Width))
                g.DrawLine(pen, Point1, Point2);
        }
    }
    [Serializable]
    public class RectangleShape : Shape
    {
        public RectangleShape() { Color = Color.Red; }
        public Rectangle Rectangle { get; set; }
        public Color Color { get; set; }
        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Color))
                g.FillRectangle(brush, Rectangle);
        }
    }
