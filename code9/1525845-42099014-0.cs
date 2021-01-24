    public abstract class ValueObjectBase
    {
        public abstract IEnumerable<object> GetEqualityCheckAttributes();
    }
    public abstract class ValueObject<T> : ValueObjectBase where T : class
    {
        public override bool Equals(object other)
        {
            if (other is ValueObjectBase)
                return Equals(other as ValueObjectBase);
            return Equals(other as T);
        }
        public bool Equals(T other)
        {
            
            if (other == null)
            {
                return false;
            }
            return other.Equals(this);
        }
        public bool Equals(ValueObjectBase other)
        {
            return GetEqualityCheckAttributes().SequenceEqual(other.GetEqualityCheckAttributes());
        }
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var obj in this.GetEqualityCheckAttributes())
            {
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());
            }
            return hash;
        }
    }
