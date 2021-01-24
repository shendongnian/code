    private ObservableCollection<DataSeriesDowngraded> _dataSeries;
    public ObservableCollection<DataSeriesDowngraded> DataSeries
    {
        get { return _dataSeriesEntries; }
        set
        {
            _dataSeries = value;
            OnPropertyChanged("DataSeries");
        }
    }
