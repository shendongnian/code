    public PositionModel Items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
            NotifyProperty("Items");
        }
    }
