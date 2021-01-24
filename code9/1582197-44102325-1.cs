    public ViewModel()
    {
        listsrc = new ObservableCollection<Pages.Product.product_data>();
        listsrc.CollectionChanged += OnCollectionChanged;
    }
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Pricesrc = listsrc.Sum(prod => prod.Price);
    }
