         public ObservableCollection<Product> Products
                {
                    get { return _products; }
                    set
                    {
                        if (value != _products)
                        {
                            _products = value;
                            OnPropertyChanged();
                        }
                    }
                }
        
                private ObservableCollection<Product> _selectedOne;
                public ObservableCollection<Product> SelectedOne
                {
                    get { return _selectedOne; }
                    set { _selectedOne = value; }
                }
        
                public int SelectedProductId
                {
                    get { return _selectedProductId; }
                    set
                    {
                        if (value != _selectedProductId)
                        {
                            _selectedProductId = value;
                            OnPropertyChanged();
                        }
                    }
                }
        
                public Product SelectedProduct
                {
                    get { return _selectedProduct; }
                    set
                    {
                        if (value !
    
    = _selectedProduct)
                    {
                        _selectedProduct = value;
    
                        // clear your list of selected objects and then add just selected one
                        // or you dont clear it, and items will be added in DataGrid when selected in ComboBox
                        SelectedOne.Clear();
                        SelectedOne.Add(_selectedProduct);
                        
                        OnPropertyChanged();
                    }
                }
            }
    
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
