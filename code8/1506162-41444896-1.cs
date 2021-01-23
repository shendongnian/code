    private IList<Item> _myList;
    [NotNull]
    public IList<Item> MyList
    {
        get { return _myList ?? (_myList = new List<Item>();) }
        set { _myList = value; }
    }
