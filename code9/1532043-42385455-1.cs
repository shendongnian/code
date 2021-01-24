        private string _ClientCount;
        public string ClientCount
        {
            get { return _ClientCount; }
            set { _ClientCount= value; RaisePropertyChanged("ClientCount"); }
        }
        private string _Port;
        public string Port
        {
            get { return _Port; }
            set { _Port= value; RaisePropertyChanged("Port"); }
        }
