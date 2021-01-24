    public class Key : IEquatable<Key>
    {
        public Key(string p1, string p2, int p3)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
        }
        public string Param1 {get;}
        public string Param2 {get;}
        public int Param3 {get;}
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int) 2166136261;
        
                hash = (hash * 16777619) ^ Param1?.GetHashCode() ?? 0;
                hash = (hash * 16777619) ^ Param2?.GetHashCode() ?? 0;
                hash = (hash * 16777619) ^ Param3.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals(other as Key);
        }
        public bool Equals(Key other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Param1,obj.Param1) && string.Equals(Param2, obj.Param2) && Param3 == obj.Param3;
        }
    }
