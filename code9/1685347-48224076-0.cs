    public class Employee : INotifyPropertyChanged 
    {
        private string _name;
        private string _organization;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Organization
        {
            get { return _organization; }
            set
            {
                _organization = value;
                RaisePropertyChanged("Organization");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
