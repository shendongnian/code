    class MyResourceManager
    {
        private readonly ResourceManager _manager;
    
        public MyResourceManager()
        {
            _manager = new ResourceManager(typeof(MyResourceManager))
        }
    
        public string GetStringResouce(string name)
        {
            return _manager.GetString(name);
        }
    }
