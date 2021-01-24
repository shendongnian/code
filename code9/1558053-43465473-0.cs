        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username= value;
                NotifyPropertyChanged("Username");
                if (<condition>)
                   PopulateData();
            }
        }
