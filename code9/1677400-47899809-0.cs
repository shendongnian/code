    public struct Range
    {
        public Range(int from, int to)
            : this()
        {
            From = from;
            To = to;
        }
        public int From { get; }
        public int To { get; }
        public override string ToString()
        {
            return $"{From} - {To}";
        }
    }
