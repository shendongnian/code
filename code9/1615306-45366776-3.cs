    private List<MyClass> _items; // store for your items
    private List<MyClass> _displayItems;
    public List<MyClass> DisplayItems // list to show
    {
        get { return _displayItems; }
        set { SetProperty(ref _displayItems, value); }
    }
    private void SearchBoxQuerySubmitted(SearchBoxQuerySubmittedEventArgs eventArgs)
    {
       searchTerm = eventArgs.QueryText?.Trim();
       Filter(searchTerm);
    }
    private void Filter(string searchTerm)
    {
       if (_items == null)
           return;
       IQueryable<MyClass> items = _items.AsQueryable();
       if (!string.IsNullOrEmpty(searchTerm))
       {
          searchTerm = searchTerm.ToLower();
          items = items.Where(x => x.productModel.Description.ToLower().Contains(searchTerm));
       }
       DisplayItems = items.ToList();
    }
