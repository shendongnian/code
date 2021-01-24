        string injector = true.ToString();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string MyItems_IsVirtualizing_Injector
        {
            get { return injector; }
            set
            {
                injector = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyItems_IsVirtualizing_Injector"));
                PropertyChanged(this, new PropertyChangedEventArgs("MyItems_IsVirtualizing"));
            }
        }
        public bool MyItems_IsVirtualizing { get { return string.Equals(true.ToString(), MyItems_IsVirtualizing_Injector); } }
