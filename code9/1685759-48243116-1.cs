    public class MyOrder
    {
        public Money Amount { get; set; }
        public MyOrderItem Lines { get; set; }
    }
    public class MyOrderItem
    {
        public ItemId ItemId { get; set; }
        public int Quantity { get; set; }
    }
    public class ItemId
    {
        public OrderItemType ItemType { get; set; }
        public string Value { get; set; }
    }
    public enum OrderItemType
    {
        Internal,
        Acme,
        BobsThirdPartyItems
    }
