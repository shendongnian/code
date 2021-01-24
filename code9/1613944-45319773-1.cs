    class Source
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
    }
    class Destination
    {
        public Guid Id { get; set; }
        public DestinationDifference Difference { get; set; }
    }
    class DestinationDifference
    {
        public decimal Amount { get; set; }
    }
