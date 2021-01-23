    public class Position
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public Position(string str)
        {
            int[] values = str.Split(new[] { "; " }, StringSplitOptions.None)
                .Select(s => Convert.ToInt32(s.Substring(s.IndexOf('=') +1))).ToArray();
            Left = values[0];
            Right = values[1];
            Top = values[2];
            Bottom = values[3];
        }
    
        public override string ToString()
        {
            return string.Join("; ", Left, Right, Top, Bottom);
        }
    }
