    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
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
                   NotifyPropertyChanged();
                }
         }
