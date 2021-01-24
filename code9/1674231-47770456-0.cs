    public class DataModel : INotifyPropertyChanged
    {
        private string _text;
        public string Name
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
