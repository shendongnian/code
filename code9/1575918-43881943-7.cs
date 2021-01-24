    class IntRangeArray
    {
        private readonly List<Range> ranges = new List<Range>();
        public bool Add(int index, string tag)
        {
            return AddRange(index, index, tag);
        }
        public bool AddRange(IEnumerable<int> indexes, string tag)
        {
            bool result = true;
            foreach (var index in indexes)
            {
                if (!Add(index, tag)) result = false;
            }
            return result;
        }
        public bool AddRange(Tuple<int, int> range, string tag)
        {
            return AddRange(range.Item1, range.Item2, tag);
        }
        public bool AddRange(int begin, int end, string tag)
        {
            if (begin < 0 || end < 0 || string.IsNullOrWhiteSpace(tag)) return false;
            var newRange = new Range { Begin = begin, End = end, Tag = tag };
            var overlappingRanges = ranges.Where(r => r.OverlapsWith(newRange)).ToList();
            if (overlappingRanges.Any())
            {
                if (overlappingRanges.All(r => r.TagEquals(newRange.Tag)))
                {
                    foreach (var overlappingRange in overlappingRanges)
                    {
                        newRange.CombineWith(overlappingRange);
                        ranges.Remove(overlappingRange);
                    }
                    
                    AddNewRange(newRange);
                    return true;
                }
            }
            else
            {
                var adjacentRanges = ranges.Where(r => r.IsAdjacentTo(newRange)).ToList();
                foreach (var adjacentRange in adjacentRanges)
                {
                    newRange.CombineWith(adjacentRange);
                    ranges.Remove(adjacentRange);
                }
                AddNewRange(newRange);
                return true;
            }
            return false;
        }
        public string At(int index)
        {
            var matchingRange = ranges.SingleOrDefault(r => r.ContainsIndex(index));
            return matchingRange?.ToString() ?? $"No item exists at {index}";
        }
        public void Remove(int index)
        {
            var matchingRange = ranges.SingleOrDefault(r => r.ContainsIndex(index));
            if (matchingRange == null) return;
            if (matchingRange.Begin == matchingRange.End)
            {
                ranges.Remove(matchingRange);
            }
            else if (index == matchingRange.Begin)
            {
                matchingRange.Begin += 1;
            }
            else if (index == matchingRange.End)
            {
                matchingRange.End -= 1;
            }
            else
            {
                // Split the range by creating a new one for the beginning
                var newRange = new Range
                {
                    Begin = matchingRange.Begin,
                    End = index - 1,
                    Tag = matchingRange.Tag
                };
                
                matchingRange.Begin = index + 1;
                AddNewRange(newRange);                
            }            
        }
        public void RemoveWithTag(string tag)
        {
            var matchingRanges = ranges.Where(r => r.TagEquals(tag)).ToList();
            foreach (var matchingRange in matchingRanges)
            {
                ranges.Remove(matchingRange);
            }
            ranges.Sort((x, y) => x.Begin.CompareTo(y.Begin));
        }
        public string TagOf(int index)
        {
            var matchingRange = ranges.SingleOrDefault(r => r.ContainsIndex(index));
            return matchingRange == null ? $"No item exists at {index}" : matchingRange.Tag;
        }
        public override string ToString()
        {
            if (ranges == null || !ranges.Any()) return "No items exist.";
            
            var output = new StringBuilder();
            for(int i = 0; i < ranges.Count; i++)
            {
                 output.AppendLine($"[{i}] {ranges[i]}");
            }
            return output.ToString();
        }
        private void AddNewRange(Range newRange)
        {
            ranges.Add(newRange);
            ranges.Sort((x, y) => x.Begin.CompareTo(y.Begin));
        }
    }
