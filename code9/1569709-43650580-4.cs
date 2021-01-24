    public decimal price 
    {
        get { return _price; }
        set 
        { 
            _price = value; 
            InvokePropertyChanged(new PropertyChangedEventArgs("price");
        }
    }
    // In windows form
    var priceBinding = new Binding("Text", sourceObject, "price", true);
    priceBinding.Format += (sender, args) => 
    {
        var price = (decimal)args.Value;
        args.Value = string.Format("{0:n0} EUR", price);
    }
    priceTextBox..DataBindings.Add(priceBinding);
