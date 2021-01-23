    // if any of the properties match, consider the class equal
    public class AnyPropertyEqualityComparer : IEqualityComparer<X>
    {
        public bool Equals(X x, X y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (object.ReferenceEquals(y, null) ||
                object.ReferenceEquals(x, null))
                return false;
            return (x.A == y.A ||
                    x.B == y.B ||
                    (x.C + x.D) == (y.C + y.D));                
        }
        public int GetHashCode(X x)
        {
            // if two objects have the same `A` value,
            // they are equal regardless of other 
            // properties (but if `A` values differ,
            // then it's impossible to tell)
            return x.A.GetHashCode();
        }
    }
