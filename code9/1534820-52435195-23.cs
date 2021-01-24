    public interface IShipper
    {
        void ShipOrder(Order ord);
        string FriendlyNameInstance { get;} /* here for my "trick" */
    }
..
    public interface IOrderProcessor
    {
        void ProcessOrder(String preferredShipperAbbreviation, Order ord);
    }
