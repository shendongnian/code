    public string SelectedSortByItem
        {
            get
            {
                return _selectedSortByItem;
            }
            set
            {
                _selectedSortByItem = value;
                OnSelectedSortByItemChanged(People, SelectedSortByItem);
                RaisePropertyChanged();
            }
        }
    public IList<People> OnSelectedSortByItemChanged(IList<People> items, string sortBy)
        {
            if (items == null || !items.Any())
            {
                return items;
            }
            var itemsToSort = items.ToList();
            if (sortBy == "FirstName")
            {
                return Sort(itemsToSort, "FirstName");
            }
            else if (sortBy == "LastName")
            {
                return Sort(itemsToSort, "LastName");
            }
            // put as many properties as you want here
      }
    private static List<People> Sort(
                List<People> itemsToSort,
                string propertyPath,
                ListSortDirection sortDirection = ListSortDirection.Ascending)
    {
       // put your sorting logic here.
    }
