    public class ThirdPartyOrderV1
    {
        public decimal Amount { get; set; }
        public ThirdPartyOrderItemV1[] LineItems { get; set; }
    }
    public class ThirdPartyOrderItemV1
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
