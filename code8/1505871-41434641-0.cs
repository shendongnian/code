    public partial class MoonDataManager
    {
        private static readonly Lazy<MoonDataManager> _manager = 
            new Lazy<MoonDataManager>(() => new MoonDataManager()); 
        public static MoonDataManager SingletonInstance => _manager.Value; 
    }
