    public class GiftVoucher
    {
        // your primary key
        public int GiftVoucherId { get; set; }
        public virtual Payment Payment { get; set; }
        // other properties
        public double Amount { get; set; }
    }
    public class Payment 
    { 
        // We need to share the same key
        public int GiftVoucherId { get; set; }
        public virtual GiftVoucher GiftVoucher { get; set; }
        // other properties
        public DateTime DateTime { get; set; }
        public double Amount { get; set; }
    }
