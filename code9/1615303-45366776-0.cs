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
          item = item.Where(x => x.productModel.Description.ToLower().Contains(searchTerm));
       }
       return item.ToList();
    }
