    public class TextboxInfo
    {
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public String Text { get; set; }
        
        public TextboxInfo(Int32 w, Int32 h, Int32 x, Int32 y, String text)
        {
            this.Width = w;
            this.Height = h
            this.X = x;
            this.Y = y
            this.Text = text;
        }
    }
