    private IList mySelectedData = new List<SelectedDataObject>();
        public IList SelectedData
        {
            get { return mySelectedData ; }
            set
            {
                if (mySelectedData != value)
                {
                    mySelectedData = value;
                    RaisePropertyChanged(() => SelectedData);
                }
            }
        }
