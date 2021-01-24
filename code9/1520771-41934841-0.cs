    public class CacheKey : IEquatable<CacheKey>
    {
        public CacheKey(string param1, string param2, int param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }
        public string Param1 { get; }
        public string Param2 { get; }
        public int Param3 { get; }
        public bool Equals(CacheKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Param1, other.Param1) && string.Equals(Param2, other.Param2) && Param3 == other.Param3;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CacheKey)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Param1?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Param2?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Param3;
                return hashCode;
            }
        }
    }
