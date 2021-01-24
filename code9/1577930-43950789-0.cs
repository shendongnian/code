    public class InventoryData
    {
        public string Inv { get; set; }
        public DateTime Date { get; set; }
        public string Term { get; set; }
        public IList<InventoryArticle> Articles { get; set; }
    }
    public class InventoryArticle
    {
        public int Quantity { get; set; }
        public string Whatever { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Tax { get; set; }
    }
