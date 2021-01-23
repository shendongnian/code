    public class DishVM
    {
        public string Pdv { get; set; }
        public int Pla_ID { get; set; }
        public decimal Price { get; set; }
        public List<int> Days { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Dishes> Data { get; set; }
    }
