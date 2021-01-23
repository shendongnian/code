        /// <summary> Assume exclusions are also given in ranges. </summary>
        public static double RangeWithExclusions(this Random random, Range range, params Range[] exclusions)
        {
            var rangeList = GetRangeList(range, exclusions);
            var rnd = random.NextDouble() * rangeList.Length;
            var rangeIndex = Array.BinarySearch(rangeList.CumulLengths, rnd);
            if (rangeIndex < 0)
            { // 'unlucky', we didn't hit a length exactly
                rangeIndex = ~rangeIndex;
            }
            var previousLength = rangeIndex > 0 ? rangeList.CumulLengths[rangeIndex - 1] : 0;
            var rndRange = rangeList.Ranges[rangeIndex]; // result range of our random draw
            return rndRange.Min + (rnd - previousLength); // scale rnd back into range space
        }
