    public sealed class NumericComparer : IComparer<string>
    {
        public static readonly IComparer<string> Instance { get; } = new NumericComparer();
        private NumericComparer() {}
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return string.Compare(x, y, StringComparison.Ordinal);
            }
            int xIndex = FindFirstNonZeroIndex(x);
            int yIndex = FindFirstNonZeroIndex(y);
            int lengthComparison = (x.Length - xIndex).CompareTo(y.Length - yIndex);
            if (lengthComparison != 0)
            {
                return lengthComparison;
            }
            return string.Compare(x, xIndex, y, yIndex, x.Length, StringComparison.Ordinal);
        }
        private static int FindFirstNonZeroIndex(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '0')
                {
                    return i;
                }
            }
            // All zeroes? Return text.Length - 1, so that we treat this as
            // "0".
            return text.Length - 1;
        }
    }
