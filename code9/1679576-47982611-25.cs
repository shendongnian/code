    public class Book : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
