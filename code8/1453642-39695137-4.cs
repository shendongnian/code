    public class TypeMapping : IStructuralEquatable
    {
        public Type From { get; private set; }
        public Type To { get; private set; }
        public TypeMapping (Type from, Type to)
        {
            From = from;
            To = to;
        }
        public override int GetHashCode()
        {
            var hash = 17;
            unchecked
            {
                hash = hash * 31 + From.GetHashCode();
                hash = hash * 31 + To.GetHashCode();
            }
            return hash;
        }
        public override Boolean Equals(Object obj) {
            return ((IStructuralEquatable) this).Equals(obj, EqualityComparer<Object>.Default);;
        }
 
        Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer) {
            if (other == null) return false;
 
            var otherMapping = other as TypeMapping;
            if (otherMapping == null) return false;
            return comparer.Equals(From, otherMapping.From) && comparer.Equals(To, otherMapping.To);
        }
    }
