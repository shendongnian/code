        private int? _value;
        public int? Value
        {
            get { return _value; }
            set {
                _value = value;
                OnPropertyChanged("Value");
                if (_value != null)
                {
                    CommandEnabled = true;
                }
            }
        }
        private bool commandEnabled = false;
        public bool CommandEnabled
        {
            get { return commandEnabled = false; }
            set {
                commandEnabled = value;
                OnPropertyChanged("CommandEnabled");
            }
        }
