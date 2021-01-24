    public static class AssetManager
    {
        private static ContentManager _common;
        public static MyContentManager Level { get; private set; }
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _common = new ContentManager(serviceProvider, "commoncontentdirectory");
            Level = new MyContentManager(serviceProvider, "levelcontentdirectory");
        }
        // A shorthand for loading an asset through the common content manager.
        public static T Load<T>(string asset)
        {
            return _common.Load<T>(asset);
        }
        // A shorthand for unloading the entire content manager for current instance.
        public static void Unload()
        {
            _common.Unload();
        }
    }
