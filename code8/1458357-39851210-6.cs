    public class Model : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                 PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
