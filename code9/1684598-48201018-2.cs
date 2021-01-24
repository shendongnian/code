    public class Song : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        private string _Artist;
        public string Artist
        {
            get { return _Artist; }
            set
            {
                _Artist = value;
                RaisePropertyChanged("Artist");
            }
        }
        private SolidColorBrush _customcolor = new SolidColorBrush(Colors.Black);
        public SolidColorBrush customcolor
        {
            get { return _customcolor; }
            set
            {
                _customcolor = value;
                RaisePropertyChanged("customcolor");
            }
        }
    }
