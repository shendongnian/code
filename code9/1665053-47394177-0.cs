    private ObservableCollection<Models.DataItem> _dataList;
    public ObservableCollection<Models.DataItem> DataList
    {
        get { return _dataList; }
        set
        {
            _dataList = value;
            RaisePropertyChanged(() => DataList); // you can use your own property notification mechanism here.
        }
    }
