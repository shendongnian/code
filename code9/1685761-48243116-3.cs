    public class ThirdPartyOrderV2
    {
        public decimal Amount { get; set; }
        public ThirdPartyOrderItemV2[] LineItems { get; set; }
        public string DontNeedThis { get; set; }
    }
    public class ThirdPartyOrderItemV2
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
