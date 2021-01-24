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
                if( PropertyChanged != null ) { PropertyChanged(this, new PropertyChangedEventArgs("Name")); }
            }
        }
        private string _name = "";
    }
