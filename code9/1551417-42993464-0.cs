    class SomeClass
    {
        private readonly Dictionary<double, int[]> Dict1 = new Dictionary<double, int[]>();
        private readonly Dictionary<double, int[]> Dict2 = new Dictionary<double, int[]>();
        private readonly Dictionary<double, int[]> Dict3 = new Dictionary<double, int[]>();
    
        public Dictionary<double, int[]> this[string index]
        {
        
            get
            {
                switch(index)
                {
                case nameof(Dict1)) return Dict1;
                case nameof(Dict2)) return Dict2;
                case nameof(Dict3)) return Dict3;
                default:
                    throw new KeyNotFoundException(index);
                }            
            }
        }
    
        public static void Main(string[] args)
        {
            var c = new SomeClass();
            c["Dict1"].Add(42.0, new [100, 200]);
            c["Dict20"].Add(43.0, new [102, 203]); //  KeyNotFoundException("Dict20")
        }
    }
