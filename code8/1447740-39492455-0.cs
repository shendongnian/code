        private bool _isFixedMode;
        public bool IsFixedMode 
        {
            get { return _isFixedMode; }
            set
            {
                _isFixedMode= value;
                if(PropertyChanged != null)
                    PropertyChange(this, new PropertyChangedEventArgs("IsFixedMode ")); 
            }
        }
