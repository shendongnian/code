    public class TestEntity : INotifyPropertyChanged
    {
        private string _name ;
        private string _surname;
        private int _age ;
        public string Name
        {
          get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
        public string Surname
        {
          get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
