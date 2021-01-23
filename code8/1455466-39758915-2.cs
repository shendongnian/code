        /// <summary> Get possible ranges to draw from, considering exclusions. </summary>
        public static RangeList GetRangeList(Range range, params Range[] exclusions)
        {
            var ranges = new List<Range>();
            ranges.Add(range);
            if (exclusions != null)
            {
                foreach (var exclusion in exclusions)
                { // progressively eat latest range added to the list, cutting exclusions.
                    var lastRange = ranges[ranges.Count - 1];
                    if (exclusion.Min < lastRange.Max)
                    {
                        ranges[ranges.Count - 1] = new Range(lastRange.Min, exclusion.Min);
                        if (exclusion.Max < lastRange.Max)
                        {
                            ranges.Add(new Range(exclusion.Max, lastRange.Max));
                        }
                    }
                }
            }
            return new RangeList(ranges.ToArray());
        }
