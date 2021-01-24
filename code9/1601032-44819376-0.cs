    public class ViewModel : INotifyPropertyChanged
    {
        private string _text;
        private bool _readOnly;
        public string Text
        {
            get { return _text; }
            set
            {
                if (ReadOnly || value == _text)
                    return;
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public string ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (value == _readOnly)
                    return;
                _readOnly = value;
                OnPropertyChanged(nameof(ReadOnly));
            }
        }
    }
