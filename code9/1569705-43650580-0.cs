    public decimal price 
    {
    get { return _price; }
    set 
    { 
        // Set price and notify that it was changed
        _price = value; 
        InvokePropertyChanged(new PropertyChangedEventArgs("price");
        InvokePropertyChanged(new PropertyChangedEventArgs("formattedPrice");
    }
    }
