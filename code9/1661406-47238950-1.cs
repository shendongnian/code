    public sealed class SingletonClass
    {
        private static ThreadLocal<SingletonClass> _instance;
        static SingletonClass()
        {
            _instance = new ThreadLocal<SingletonClass>(() => new SingletonClass());
        }
        public static SingletonClass Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private SingletonClass()
        {
        }
    }
