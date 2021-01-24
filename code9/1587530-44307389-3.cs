    public class ViewList : INotifyPropertyChanged
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("id"));
            }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if((value as string) != null)
                {
                    _description = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("description"));
                }
            }
        }
        private string _code;
        public string code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged(new PropertyChangedEventArgs("code"));
            }
        }
        private bool _isEnabled;
        public bool isEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isEnabled"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
