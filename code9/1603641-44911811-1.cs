    public static class ServiceLocatorOfIMap
    {
        static IMap _service;
        public static IMap GetService()
        {
            return _service;
        }
        public static void Provide(IMap service)
        {
            _service = service;
        }
    }
    public static class ServiceLocatorOfICamera 
    {
        static ICamera _service;
        public static ICamera GetService()
        {
            return _service;
        }
        public static void Provide(ICamera service)
        {
            _service = service;
        }
    }
