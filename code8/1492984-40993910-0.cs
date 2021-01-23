        private bool _testRadio;
        public bool TestRadio
        {
            get { return _testRadio; }
            set { value = testradiohandler(); SetProperty(ref _testRadio, value); }
        }
        private bool testradiohandler()
        {
            return new Random().NextDouble() >= 0.5;
        }
