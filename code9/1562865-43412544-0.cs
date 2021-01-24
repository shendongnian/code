    #region MakeItemsLarge Property
    private bool _makeItemsLarge = false;
    public bool MakeItemsLarge
    {
        get { return _makeItemsLarge; }
        set
        {
            if (value != _makeItemsLarge)
            {
                _makeItemsLarge = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion MakeItemsLarge Property
