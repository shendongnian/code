    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            get { return _name; }
            set
            {
                if(_name == value) { return; }
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private string _name = "";
    }
