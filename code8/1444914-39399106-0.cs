    public class Triangle : IEquatable<Triangle>
    {
        bool IEquatable<Triangle>.Equals(Triangle other)
        {
            return Equals(other);
        }
        public override bool Equals(object obj)
        {
            //...
        }
        public override int GetHashCode()
        {
            //...
        }
    }
