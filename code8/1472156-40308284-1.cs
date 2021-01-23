    class Log : INotifyPropertyChanged
    {
        private string _logContent;
        public string logContent
        {
            get { return _logContent; }
            set { _logContent = value; OnPropertyChanged(); }
        }
        private static Log instance;
        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                }
                return instance;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
