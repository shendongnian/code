    class Locator
    {
        private LViewModel _lInstance;
        public LViewModel LInstance
        {
            get { return _lInstance ?? (_lInstance = new LInstance()); }
        }
        ....
    }
