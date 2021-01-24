    private class NoCons
    {
        private NoCons()
        {
        }
        private static NoCons _instance;
        public static NoCons Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NoCons();
                }
                return _instance;
            }
        }
    }
