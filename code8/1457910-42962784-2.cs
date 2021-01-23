    public class OrderLine
    {
        public string ItemNo { get; set; }
        (many other properties here...)
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
    }
