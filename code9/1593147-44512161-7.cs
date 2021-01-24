    private ObservableCollection<Product> _ProductsView;
    public ObservableCollection<Product> ProductsView
        {
            get { return _ProductsView; }
            set
            {
                _ProductsView = value;
                NotifyPropertyChanged();
            }
        }
