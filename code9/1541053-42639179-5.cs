    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }
        public float Xf { get { return (float)X; } }
        public float Yf { get { return (float)Y; } }
        public PointF PointF { get { return new PointF(Xf, Yf); } }
        public PointD()
        { }
        public PointD(double cX, double cY)
        {
            X = cX;
            Y = cY;
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }
    }
