    class Abc
    {
        private static object _resource;
        static Abc()
        {
            _resource = new object();
        }
        public static void Method1()
        {
            lock (_resource)
            {
                // this will run for only one thread at a time
            }
        }
        public static void Method2()
        {
            lock (_resource)
            {
                // this will run for only one thread at a time
            }
        }
    }
