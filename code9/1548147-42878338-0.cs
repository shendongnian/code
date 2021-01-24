    public interface IShippingDispatcher
    {
        void Ship(string shipper, Product product);
    }
    
    public class ShippingDispatcher : IShippingDispatcher
    {
        private readonly Func<string, IShipper> factory;
        public ShippingDispatcher(Func<string, IShipper> factory) { this.factory = factory; }
        public void Ship(string shipper, Product product) => factory(shipper).Ship(product);
    }
