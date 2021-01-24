        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _id;
        public int id 
        { 
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string something{ get; set; }
        public string currentState { get; set; }
    }
