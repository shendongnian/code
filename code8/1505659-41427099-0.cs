    public class RangeDictionary<T> : Dictionary<Range, T>
    {
        public void Add(int from, int to, T value)
        {
            Add(new Range(from, to), value);
        }
        public IEnumerable<KeyValuePair<Range, T>> FindIntersection(int from, int to)
        {
            return this.Where(x => x.Key.IntersectWith(from, to));
        }
    }
    public struct Range
    {
        public Range(int from, int to)
            : this()
        {
            From = from;
            To = to;
        }
        public int From { get; private set; }
        public int To { get; private set; }
        public bool IntersectWith(int from, int to)
        {
            return this.From <= to && this.To >= from;
        }
    }
