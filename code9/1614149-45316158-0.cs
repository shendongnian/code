    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int? Code { get; set; }
        public int Amount { get; set; }
        ... // other fields
    }
