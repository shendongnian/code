    class ViewModel : INotifyPropertyChanged
    {
        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { _UpdateField(ref _text, value); }
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
                // empty
            }
        }
    }
