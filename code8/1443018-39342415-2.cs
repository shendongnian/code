    public class MyClass : INotifyPropertyChanged
    {       
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
