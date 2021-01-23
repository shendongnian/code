    [Serializable]
    public class SerSolidBrush 
    {
        public SerColor sColor { get; set; }
        public SerSolidBrush() { }
        public SerSolidBrush(Color c)
        {
            sColor = new SerColor(c);
        }
        public SerSolidBrush(SolidBrush b)
        {
            sColor = new SerColor(b.Color);
        }
        public SolidBrush SolidBrush()
        {
            Color c = SerColor.Color(sColor);
            return new System.Drawing.SolidBrush(c);
        }
        static public SolidBrush SolidBrush(SerSolidBrush b)
        {
            Color c = SerColor.Color(b.sColor);
            return new System.Drawing.SolidBrush(c);
        }
    }
