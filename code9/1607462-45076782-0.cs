    private ObservableCollection<YourType> _sourceCollection;
    public ObservableCollection<YourType> SourceCollection
    {
        get { return _sourceCollection; }
        set
        {
            _sourceCollection = value;
            RaisePropertyChanged();
            SourceUpdated.Execute(null);
        }
    }
