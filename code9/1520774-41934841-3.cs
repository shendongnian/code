    public class CacheKey : MemberwiseEquatable<CacheKey>
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
    }
