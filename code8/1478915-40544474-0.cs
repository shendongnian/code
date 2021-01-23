    public class Customer : INotifyPropertyChanged
    {
        string _firstname = "";
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged("Firstname"); }
        }
        string _lastname = "";
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; OnPropertyChanged("Lastname"); }
        }
        int _age = 0;
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        } 
        public Customer()
        {
        }
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
