    struct Interval
    {
        public Interval(double lower, double upper)
        {
            if (upper <= lower)
                throw new ArgumentException("The upper bound must be greater than the specified lower bound", nameof(upper));
            LowerBound = lower;
            UpperBound = upper;
        }
        public double LowerBound { get; }
        public double UpperBound { get; }
        public override string ToString()
        {
            if (UpperBound == double.PositiveInfinity)
                return $" > {LowerBound}";
            return $"{LowerBound} - {UpperBound}";
        }
    }
