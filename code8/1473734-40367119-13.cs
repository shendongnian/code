    using System;
    using System.Drawing;
    public class ReportColumn
    {
        public ReportColumn(string name)
        {
            Name = name;
            Title = name;
            Type = typeof(System.String);
            Width = GetPixelFromInch(1);
            Expression = string.Format("=Fields!{0}.Value", name);
            HeaderBackColor = Color.LightGray;
        }
        public string Name { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public int Width { get; set; }
        public float WidthInInch
        {
            get { return GetInchFromPixel(Width); }
        }
        public string Expression { get; set; }
        public Color HeaderBackColor { get; set; }
        public string HeaderBackColorInHtml
        {
            get { return ColorTranslator.ToHtml(HeaderBackColor); }
        }
        private int GetPixelFromInch(float inch)
        {
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
                return (int)(g.DpiY * inch);
        }
        private float GetInchFromPixel(int pixel)
        {
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
                return (float)pixel / g.DpiY;
        }
    }
