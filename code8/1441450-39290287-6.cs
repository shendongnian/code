    public ObservableCollection<Product> ProductList
    {
        get { return productList; }
        set
        {
            productList = value;
            ProductListView = CollectionViewSource.GetDefaultView(value);
            ProductListView.Filter = FilterMethod;
        }
    }
    
