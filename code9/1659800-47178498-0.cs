        private bool _isVisible = false;
        public bool IsVisible
        {
            get
            {
                return _isVisible
            }
            set
            {
                Set(() => IsVisible, ref _isVisible, value);
            }
        }
