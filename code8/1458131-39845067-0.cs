        public string stringProperty
        {
            get { return _stringProperty; }
            set
            {
                if (!_stringProperty.Equals(value))
                {
                    _stringProperty = value;
                    OnPropertyChanged("stringProperty");  //Notify UI only if there is new value
                }
            }
        }
