        private static volatile UIRepository instance;
        private static object syncRoot = new Object();
        private UIRepository(){}
        public static UIRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UIRepository();
                    }
                }
                return instance;
            }
        }
        private string _currentClientId;
        public string CurrentClientId
        {
            get { return _currentClientId; }
            set { _currentClientId = value; }
        }
    
