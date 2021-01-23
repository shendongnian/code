    [Serializable]
    public class SerColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }
        public SerColor() { }
        public SerColor(Color c)
        { Red = c.R;  Green = c.G; Blue = c.B; Alpha = c.A; }
        static public Color Color(SerColor c)
        { return System.Drawing.Color.FromArgb(c.Alpha, c.Red, c.Green, c.Blue); }
    }
