    class ViewModel : INotifyPropertyChanged
    {
        private int _textLength;
        public int TextLength
        {
            get { return _textLength; }
            set { _UpdateField(ref _textLength, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                _OnPropertyChanged(propertyName);
            }
        }
        private void _OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                // you can add "case nameof(...):" cases here to handle
                // specific property changes, rather than polluting the
                // property setters themselves
            }
        }
    }
