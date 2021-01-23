    private ITEM_ACTIVE _itemData;
    public string ThumbnailUNC { get; private set; }
    public ITEM_ACTIVE ITEMDATA 
    { 
        get 
        {
            return _itemData;
        }
        set
        {
            _itemData = value;
            ThumbnailUNC = value.PART_NUMBER;
        }
    }
