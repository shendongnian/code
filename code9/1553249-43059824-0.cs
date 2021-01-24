        public bool ShowAllColumns
        {
            get { return _bShowAllColumns; }
            set
            {
                if(_bShowAllColumns != value)
                {
                    _bShowAllColumns = value;
                    OnPropertyChanged("ShowAllColumns");
                }
            }
        }
