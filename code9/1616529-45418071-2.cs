    public ICollectionView CompanyItemCollectionView
    {
        get
        {
            ICollectionView view = new CollectionViewSource { Source = CompanyItems }.View;
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending)); //example                
            return view;
        }
    } 
