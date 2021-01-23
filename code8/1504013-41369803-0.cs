    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public class ValidateRanges
    {
        private readonly List<Range> _ranges;
        private readonly Func<int, bool> _validate;
        public ValidateRanges(List<Range> ranges, Func<int, bool> validate)
        {
            _ranges = ranges;
            _validate = validate;
        }
        bool IsInRange(int value)
        {
            return _ranges.Any(range => value > range.Min && value < range.Max);
        }
        public bool Validate(int value)
        {
           return validate(value);
        }
    }
