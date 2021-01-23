    public class MySingleInstanceClass
    {
        public static readonly MySingleInstanceClass Instance { get; private set; }
    
        static MySingleInstanceClass
        {
            Instance = new MySingleInstanceClass();
        }
    
        // Use a private constructor so no one besides your own class can create an instance of it
        private MySingleInstanceClass()
        {
        }
        public string SomeProperty { get; set; }
    }
