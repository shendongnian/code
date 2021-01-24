    class Singleton
    {
        private static Lazy<Singleton> singleton = new Lazy<Singleton>(()=> new Singleton());
        private Singleton() { }
        public static Singleton getInstance()
        {
            return singleton.Value;
        }
        public string Message { get; set; }
    }
