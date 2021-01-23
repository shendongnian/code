     private DataView dt;
            public DataView DT
            {
    
                get
                {
                    return dt;
                }
                set
                {
                    dt = value;
                    NotifyPropertyChanged("DT");
                }
            }
