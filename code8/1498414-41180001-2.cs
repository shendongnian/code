    public class AnotherClass
    {
        private static AnotherClass instance;
    
        private AnotherClass() { }
    
        public static AnotherClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnotherClass();
                    
                }
                return instance;
            }
        }
    
        public IList<string> MyList { get; set; } = new List<string>
        {
            "one",
            "three"
        };
    }
