    private ICollectionView productListView = null;
    public ICollectionView ProductListView
    {
       get { return productListView; }
       set { productListView = value; NotifyPropertyChanged("ProductListView"); }
    }
    private ObservableCollection<Product> productList;
