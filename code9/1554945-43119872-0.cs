        private bool _isEnabled;
        public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				_isEnabled = value;
				RaisePropertyChanged("IsEnabled");
			}
		}
