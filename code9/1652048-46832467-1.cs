    public class DocType : INotifyPropertyChanged
    {
        [XmlElement]
        public string Name { get; set; }
        private bool _isChecked;
        [XmlElement]
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
