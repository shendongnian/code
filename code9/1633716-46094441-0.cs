    public class MainViewModel : INotifyPropertyChanged
    {
        private string _hello;
        public string hello
        {
            get { return _hello; }
            set
            {
                _hello = value;
                OnPropertyChanged();
            }
        }
        ...
    }
