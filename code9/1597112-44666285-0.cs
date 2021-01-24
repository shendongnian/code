    public sealed class GlobalInfo
    {
        private static readonly GlobalInfo _instance;
        public int Orden { get; set; }
        private GlobalInfo() { }
        public static GlobalInfo Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalInfo();
                }
                return _instance;
            }
        }
    }
