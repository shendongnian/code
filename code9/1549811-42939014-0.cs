    public MainViewModel()
    {
        IList<ItemFilter> itemFilter = new List<ItemFilter>();
        itemFilter.Add(new ItemFilter() { Id = 0, Name = "All" });
        itemFilter.Add(new ItemFilter() { Id = 1, Name = "One" });
        itemFilter.Add(new ItemFilter() { Id = 2, Name = "Two" });
        ItemFilters = itemFilter;
        SelectedItemFilter = itemFilter[0];
    }
    public IList<ItemFilter> ItemFilters { get; }
    public ItemFilter SelectedItemFilter
    {
        get { return _selectedItemFilter; }
        set { SetProperty(ref _selectedItemFilter, value); }
    }
