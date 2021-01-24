    class Singleton
    {
        private static Singleton singleton = null;
        private Singleton(){}
        public static Singleton getInstance()
        {
            if (singleton!=null)
            {
                return singleton;
            }
            return (singleton = new Singleton()); //here is
        }
        public string Message{get; set;}
    }
