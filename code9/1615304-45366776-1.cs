    private void SearchBoxQuerySubmitted(SearchBoxQuerySubmittedEventArgs eventArgs)
    {
       searchTerm = eventArgs.QueryText?.Trim();
       Filter(searchTerm);
    }
    private List<MyClass> Filter(string searchTerm)
    {
       if (Items == null)
           return;
       IQueryable<MyClass> items = Items.AsQueryable();
       if (!string.IsNullOrEmpty(searchTerm))
       {
          searchTerm = searchTerm.ToLower();
          items = items.Where(x => x.productModel.Description.ToLower().Contains(searchTerm));
       }
       return items.ToList();
    }
