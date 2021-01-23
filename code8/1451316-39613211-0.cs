    public class SomeClass
    {
        //single instance used everywhere.
        private static SomeClass _instance;
    
        //private constructor so only the GetInstance() method can create an instance of this object.
        private SomeClass()
        {
    
        }
    
    
        //get single instance
        public static SomeClass GetInstance()
        {
            if (_instance != null) return _instance;
            return _instance = new SomeClass();
        }
    }
