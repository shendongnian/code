        private Page _ContentView;
        public Page ContentView
        {
            get
            {
                if (_ContentView == null) { _ContentView = ViewLicenceManager; }
                return _ContentView;
            }
            set
            {
                Set(ref _ContentView, value);
            }
        }
