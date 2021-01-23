    /// <summary> A possible range of values. </summary>
    public struct Range
    {
        /// <summary> Min value, inclusive. </summary>
        public readonly double Min;
        /// <summary> Max value, inclusive. </summary>
        public readonly double Max;
        public Range(double min, double max) { Min = min; Max = max; }
        /// <summary> Range length, distance between Min and Max. </summary>
        public double Length { get { return Max - Min; } }
    }
