    [Serializable]
    public class SerPen 
    {
        public SerColor sColor { get; set; }
        public float width { get; set; }
        public LineJoin lineJoin  { get; set; }
        // constructors
        public SerPen() { width = 1f; }
        public SerPen(Color c, float w)
        {
            sColor = new SerColor(c);
            width = w;
        }
        public SerPen(Pen p)
        {
            sColor = new SerColor(p.Color);
            width = p.Width;
            lineJoin = p.LineJoin;
        }
        // re-constructors
        public Pen  Pen ()
        {
            Color c = SerColor.Color(sColor);
            Pen pen = new System.Drawing.Pen (c, width);
            pen.LineJoin = lineJoin;
            return pen;
        }
        static public Pen  Pen (SerPen p)
        {
            Color c = SerColor.Color(p.sColor);
            Pen pen = new System.Drawing.Pen (c, p.width);
            pen.LineJoin = p.lineJoin;
            return pen;
        }
    }
