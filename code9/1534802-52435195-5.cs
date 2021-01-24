    public interface IShipper
    {
        void ShipOrder(Order ord);
        string FriendlyNameInstance { get;}
    }
..
    public interface IOrderProcessor
    {
        void ProcessOrder(String preferredShipperAbbreviation, Order ord);
    }
