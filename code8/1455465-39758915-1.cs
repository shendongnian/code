    /// <summary> All possible ranges grouped together. </summary>
    public struct RangeList
    {
        /// <summary> Possible range. </summary>
        public readonly Range[] Ranges;
        /// <summary> Sum of each range length. </summary>
        public readonly double Length;
        /// <summary> Cumulative lengths values of each ranges. </summary>
        public readonly double[] CumulLengths;
        public RangeList(Range[] ranges)
        {
            Ranges = ranges;
            Length = 0;
            CumulLengths = new double[ranges.Length];
            for (var i = 0; i < ranges.Length; ++i)
            {
                Length += ranges[i].Length;
                CumulLengths[i] = Length;
            }
        }
    }
