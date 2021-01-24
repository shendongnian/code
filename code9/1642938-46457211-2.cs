    public class MyConfigData
    {
        ushort EntityIdSite { get; set; }
        ushort EntityIdApplication { get; set; }
        ushort ETypeCountry { get; set; }
        byte ETypeCategory { get; set; }
        byte ETypeSubCategory { get; set; }
        public UInt32 PortNumber { get; set; }
        private static MyConfigData _instance;
        // Lock synchronization object
        private static object syncLock = new object();
        protected MyConfigData()
        {
        }
        public static MyConfigData GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new MyConfigData();
                    }
                }
            }
            return _instance;
        }
    }
