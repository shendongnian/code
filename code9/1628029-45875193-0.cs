            public ObservableCollection<Product> ProductsList { set; get; }
            public Product SelectedProduct
            {
                set
                {
                    _selectedProduct = value;
                    NotifyPropertyChanged();
                }
                get
                {
                    return _selectedProduct;
                }
            }
