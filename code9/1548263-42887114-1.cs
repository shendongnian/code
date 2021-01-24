    public void Ship(String shipper, Product product)
    {
        var contract = shipper.ParseContract("contract.csv");
    
        dynamic shipper = container.GetInstance(
            typeof(IShipper<>).MakeGenericType(contract.GetType()));
    
        shipper.Ship((dynamic)contract, product);
    }
