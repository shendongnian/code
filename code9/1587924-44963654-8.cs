    public FlowDocument FlowDoc
        {
            get
            {
                return _flowDoc;
            }
            set
            {
               _flowDoc = value;
               OnPropertyChanged("FlowDoc");
            }
        }
