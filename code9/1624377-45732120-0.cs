    public class Translations : INotifyPropertyChanged
    {
        private string _sample;
        public string Sample
        {
            get { return _sample; }
            set { _sample = value; OnPropertyChanged("Sample"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
