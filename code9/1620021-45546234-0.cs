    public struct mappingData
    {
        public string a;
        public string b;
        public int c;
        public override bool Equals(Object obj) 
        {
           return obj is mappingData && this == (mappingData)obj;
        }
        public override int GetHashCode() 
        {
           return a.GetHashCode() ^ a.GetHashCode() ^ c;
        }
        public static bool operator ==(mappingData x, mappingData y) 
        {
           return x.a == y.a && x.b == y.b && x.c == y.c;
        }
        public static bool operator !=(mappingData x, mappingData y) 
        {
           return !(x == y);
        }
    }
