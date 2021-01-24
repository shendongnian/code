    class ViewModel : INotifyPropertyChanged
    {
        private string _text;
        private int _textLength;
        public string Text
        {
            get { return _text; }
            set { _UpdateField(ref _text, value); }
        }
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
                case nameof(Text):
                    TextLength = Text.Length;
                    break;
            }
        }
    }
