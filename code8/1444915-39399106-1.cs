    public class TriangleComparer : IEqualityComparer<Triangle>
    {
        public bool Equals(Triangle x, Triangle y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(Triangle obj)
        {
            return obj.GetHashCode();
        }
    }
