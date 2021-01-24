    private ICollectionView _ojectInfoItems;
    public ICollectionView ObjectInfoItems
    {
        get { return myVar; }
        set { myVar = value; OnPropertyChanged(); }
    }
    public ObjectViewModel()
    {
        Task.Factory.StartNew(() =>
        {
            return ObjectProperties.Instance.GetAttributeObjectAttributes();
        }).ContinueWith(task =>
        {
            ObjectInfoItems = CollectionViewSource.GetDefaultView(task.Result);
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
