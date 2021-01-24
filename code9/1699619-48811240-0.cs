    public class Test : INotifyPropertyChanged
    {
        public string test2
        {
            get { return _test2; }
            set { _test2 = value; OnPropertyChanged(nameof(test2)); }
        }
        ...
    }
