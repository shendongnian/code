        public string SerialNumber
        {
            get { return _sn; }
            set { _sn = value; NotifyPropertyChanged(nameof(_sn)); }
        }
