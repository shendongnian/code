    private ICollectionView _commendationView;
    public ICollectionView CommendationView
    {
        get { return _commendationView; }
        set { _commendationView = value; NotifyPropertyChanged(); }
    }
