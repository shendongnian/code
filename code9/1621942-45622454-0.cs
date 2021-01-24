    public sealed class MyDictionary
    {
        private static readonly Dictionary<int, int> instance = new Dictionary<int, int>();
    
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MyDictionary()
        {
        }
    
        private MyDictionary()
        {
        }
    
        public static IDictionary<int, int> Instance
        {
            get
            {
                return instance;
            }
        }
    }
