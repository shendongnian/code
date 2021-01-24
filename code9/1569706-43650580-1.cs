    public decimal price 
    {
        get { return _price; }
        set 
        { 
            _price = value; 
            InvokePropertyChanged(new PropertyChangedEventArgs("price");
            InvokePropertyChanged(new PropertyChangedEventArgs("formattedPrice");
        }
    }
