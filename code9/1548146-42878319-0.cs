     public interface IShipper
     {
         string Name { get; }
         void Ship(Product product)
     }
    public Setup()
    {
        var container = new SimpleInjector.Container();
        // TODO: Registration required for two different shippers
        container.RegisterCollection<IShipper>(new[] { new UPS(), new FedEx() });
    }
    public void Ship(string shipperName, Product product)
    {
        // TODO: Retrieve the shipper by name
        var shippers = container.GetAllInstances<IShipper>();
        var shipper = shippers.FirstOrDefault(x => x.Name == shipperName);
        // TODO: do null check on shipper
        shipper.Ship(product);
    }
