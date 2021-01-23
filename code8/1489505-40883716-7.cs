    private ObservableCollection<ProductDisplay> _productList;
     public ObservableCollection<ProductDisplay> ProductList
     {
         get
            {
                return _productList;
            }
        set
            {
                _productList = value;
                RaisePropertyChanged(()=>ProductList);
            }
     }
