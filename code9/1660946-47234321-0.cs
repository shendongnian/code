        public string Text
        {
            get => _text;
            set
            {
                OnPropertyChanged(nameof(Text));
                _text = value;
            }
        }
        private string _text;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
