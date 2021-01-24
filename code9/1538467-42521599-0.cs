    public class Items : INotifyPropertyChanged
    {
        public string Time { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Results { get; set; }
        public string FlagImage { get; set; }
        public string bull1 { get; set; }
        public string bull2 { get; set; }
        public string bull3 { get; set; }
        private Brush _brush;
        public Brush Color
        {
            get { return _brush; }
            set
            {
                _brush = value;
                RaisePropertyChanged("Color");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
