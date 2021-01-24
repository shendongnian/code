    decimal _sellPrice;
    public decimal SellPrice
    {
        get
        {
            return _sellPrice;
        }
        set
        {
            _sellPrice = value;
        }
    }
    public string SellPriceString
    {
        get
        {
            return _sellPrice.ToString("C2");
        }
    }
