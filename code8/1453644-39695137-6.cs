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
            return ((IStructuralEquatable) this).GetHashCode(EqualityComparer<Object>.Default);
        }
    
        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            var hash = 17;
            unchecked
            {
                hash = hash * 31 + From.GetHashCode();
                hash = hash * 31 + To.GetHashCode();
            }
            return hash;
        }
    
        public override bool Equals(Object obj) {
            return ((IStructuralEquatable) this).Equals(obj, EqualityComparer<Object>.Default);
        }
    
        bool IStructuralEquatable.Equals(Object other, IEqualityComparer comparer) {
            if (other == null) return false;
    
            var otherMapping = other as TypeMapping;
            if (otherMapping == null) return false;
    
            return comparer.Equals(From, otherMapping.From) && comparer.Equals(To, otherMapping.To);
        }
    }
