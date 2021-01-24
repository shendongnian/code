    public const string ItemsCollectionPropertyName = "ItemsCollection";
    private ObservableCollection<DataItem> _itemsCollection = null;
    public ObservableCollection<DataItem> ItemsCollection
    {
    	get
    	{
    		return _itemsCollection;
    	}
    	set
    	{
    		if (_itemsCollection == value)
    		{
    			return;
    		}
    
    		_itemsCollection = value;
    		RaisePropertyChanged(ItemsCollectionPropertyName);
    	}
    }
