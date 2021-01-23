    public class A
    {
        private static A _instance;
        public static A Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new A();
                }
                return _instance;
            }
            set { _instance = value; }
        }
    }
    public class B : A
    {
        
    }
    A.Instance = new B();
