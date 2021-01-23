    public sealed class MySingleInstanceClass
    {
        private static readonly MySingleInstanceClass instance = new MySingleInstanceClass();
        
        public static MySingleInstanceClass Instance 
        { 
            get
            {
                return instance;
            }
        }
        static MySingleInstanceClass()
        {
        }
        // Use a private constructor so no one besides your own class can create an instance of it
        private MySingleInstanceClass()
        {
        }
        public string SomeProperty { get; set; }
    }
