    private Item _Item;
    public Item Item
    {
        get { return _Item; }
        set
        {
            _Item = value;
            RaiseProperChanged();
            RaiseProperChanged(nameof(Weight));
        }
    }
    private int _Count;
    public int Count
    {
        get { return _Count; }
        set
        {
            _Count = value;
            RaiseProperChanged();
            RaiseProperChanged(nameof(Weight));
        }
    }
