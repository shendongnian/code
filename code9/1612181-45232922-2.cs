    public class Ausstattung : INotifyPropertyChanged
    {
        private string _textValue;
        public string TextValue
        {
            get => _textValue;
            set
            {
                _textValue = value;
                OnPropertyChanged();
            }
        }
