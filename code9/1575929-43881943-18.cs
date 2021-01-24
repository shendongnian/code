    class Range
    {
        public int Begin { get; set; }
        public int End { get; set; }
        public string Tag { get; set; }
        public bool CombineWith(Range other)
        {
            Range combinedRange;
            if (TryCombine(this, other, out combinedRange))
            {
                this.Begin = combinedRange.Begin;
                this.End = combinedRange.End;
                return true;
            }
            return false;
        }
        public bool IsAdjacentTo(Range other)
        {
            return AreAdjacent(this, other);
        }
        public bool OverlapsWith(Range other)
        {
            return AreOverlapping(this, other);
        }
        public bool ContainsIndex(int index)
        {
            return this.Begin <= index && this.End >= index;
        }
        public bool TagEquals(string tag)
        {
            if (this.Tag == null) return tag == null;
            return this.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase);
        }
        public static bool TryCombine(Range first, Range second, out Range combined)
        {
            combined = new Range();
            if (first == null || second == null) return false;
            if (!TagsEqual(first, second)) return false;
            if (!AreAdjacent(first, second) && !AreOverlapping(first, second)) return false;
            
            combined.Begin = Math.Min(first.Begin, second.Begin);
            combined.End = Math.Max(first.End, second.End);
            combined.Tag = first.Tag;
            return true;
        }
        public static bool AreAdjacent(Range first, Range second)
        {
            if (first == null || second == null) return false;
            if (!Range.TagsEqual(first, second)) return false;
            return (first.Begin == second.End + 1) ||
                   (first.End == second.Begin - 1);
        }
        public static bool AreOverlapping(Range first, Range second)
        {
            if (first == null || second == null) return false;
            return (first.Begin >= second.Begin && first.Begin <= second.End) ||
                   (first.End >= second.Begin && first.End <= second.End);
        }
        public static bool TagsEqual(Range first, Range second)
        {
            if (first == null || second == null) return false;
            return first.TagEquals(second.Tag);
        }
        public override string ToString()
        {
            return $"begin: {Begin}, end: {End}, tag: {Tag}";
        }
    }
