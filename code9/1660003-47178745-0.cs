    // Leaving out locking and error handling
    public static Lexicon
    {
        private static Func<string, string> _lookup=null;
        public static void Initialize(Func<string, string> lookup)
        {
            _lookup=lookup;
        }
        public static string Translate(string key)
        {
            return _lookup(key);
        }
    }
    
