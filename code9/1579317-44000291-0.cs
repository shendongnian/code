        public string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
                OnPropertyUpdated(Display);
            }
        }
