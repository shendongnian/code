        private bool _isToggleButtonChecked;
        public bool IsToggleButtonChecked
        {
            get { return _isToggleButtonChecked; }
            set
            {
                if (_isToggleButtonChecked)
                    return;
                _isToggleButtonChecked = value;
                RaisePropertyChanged("IsToggleButtonChecked");
            }
        }
        private void ResetIsToggleButtonChecked()
        {
            _isToggleButtonChecked = false;
            RaisePropertyChanged("IsToggleButtonChecked");
        }
