    class OrderData
    {
        public string OrderName { get; set; }
        public int Ticket1Sum { get; set; }
        public int Ticket2Sum { get; set; }
    }
    class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Ticket1
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int OrderId { get; set; }
    }
    class Ticket2
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int OrderId { get; set; }
    }
