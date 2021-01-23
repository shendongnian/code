    public struct Position
    {
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }
    
        public Position(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    
        public Position(string positionText)
        {
            string basePattern = "=(?<value>[\\d\\-]+)";
            int left = Convert.ToInt32(Regex.Match(positionText, "l" + basePattern).Groups["value"].Value);
            int top = Convert.ToInt32(Regex.Match(positionText, "t" + basePattern).Groups["value"].Value);
            int right = Convert.ToInt32(Regex.Match(positionText, "r" + basePattern).Groups["value"].Value);
            int bottom = Convert.ToInt32(Regex.Match(positionText, "b" + basePattern).Groups["value"].Value);
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    
        public Position Move(int leftDelta = 0, int topDelta=0, int rightDelta=0, int bottomDelta = 0)
        {
            return new Position(Left + leftDelta, Top + topDelta, Right + rightDelta, Bottom + bottomDelta);
        }
    
        public override string ToString()
        {
            return string.Format("l={0}; r={1}; t={2}; b={3}", Left, Right, Top, Bottom);
        }
    }
