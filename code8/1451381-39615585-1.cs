    private List<OwnerModel> _haveList;
        public List<OwnerModel> HaveList
        {
            get { return _haveList; }
            set
            {
                if (value != _haveList)
                {
                    _haveList = value;
                    RaisePropertiesChanged("HaveList");
                }
            }
        }
