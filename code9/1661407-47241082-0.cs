    public sealed class SingletonClass
    {
        [ThreadStatic]
        private static SingletonClass _instance;
        public static SingletonClass Instance
        {
            get
            {
                return _instance;
            }
        }
        static SingletonClass()
        {
            _instance = new SingletonClass();
        }
    }
