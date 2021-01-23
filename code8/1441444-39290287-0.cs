    public ObservableCollection<Product>
    {
        get { return productList; }
        set
        {
            productList = value;
            ProductListView = CollectionViewSource.GetDefaultView(value);
            ProductListView.Filter = FilterMethod;
        }
    }
    
