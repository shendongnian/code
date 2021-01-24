    public Setup()
    {
        container.Register(typeof(IShipper<>), new[] { typeof(FedEx).Assembly });
    }
    
    public void Ship(String shipper, Product product)
    {
        var contract = shipper.ParseContract("contract.csv");
    
        dynamic shipper = container.GetInstance(
            typeof(IShipper<>).MakeGenericType(contract.GetType()));
    
        shipper.SetContract((dynamic)contract);
    
        shipper.Ship(product);
    }
