    public class SampleComparer : IEqualityComparer<Sample>
    {
        public bool Equals(Sample x, Sample y)
        {
            return x.property == y.property &&
                Enumerable.SequenceEqual(x.someListProperty, y.someListProperty);
        }
        public int GetHashCode(Sample obj)
        {
            // Implement
        }
    }
