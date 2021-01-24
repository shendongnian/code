        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Username
        {
            get { return username; }
            set
            {
                if (username == value) return;
                username = value?.ToLowerInvariant();
                OnPropertyChanged();
            }
        }
