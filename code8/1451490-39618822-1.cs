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
            string pattern = @"(?=l=(?<left>[\d\-]+))|(?=t=(?<top>[\d\-]+))|(?=r=(?<right>[\d\-]+))|(?=b=(?<bottom>[\d\-]+))";
            Match match = Regex.Match(positionText, pattern);
            int left = Convert.ToInt32(match.Groups["left"].Value);
            int top = Convert.ToInt32(match.Groups["top"].Value);
            int right = Convert.ToInt32(match.Groups["right"].Value);
            int bottom = Convert.ToInt32(match.Groups["bottom"].Value);
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
