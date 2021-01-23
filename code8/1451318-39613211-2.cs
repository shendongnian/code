    public class SomeClass
    {
    
        private static SomeClass _instance;
    
    
        private SomeClass()
        {
    
        }
        public static SomeClass GetInstance()
        {
            if (_instance == null)
                throw new Exception("Call SetInstance() with a valid object");
            return _instance;
        }
    
        public static void SetInstance(SomeClass obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            _instance = obj;
        }
    }
