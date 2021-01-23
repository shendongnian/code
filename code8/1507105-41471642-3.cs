    class Order
    {
        public int OrderId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int OrderNumber { get; set; }
    }
