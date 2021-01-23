    public class Student : NotifyProperty
    {
        public string Name
        {
            set
            {
                _name = value;
                OnPropertyChanged();
            }
            get
            {
                return _name;
            }
        }
        private string _name;
    }
