    public class Customer 
    {
        public string Name { get; set; }
        public List<Contract> Contracts { get; set; }
    }
    public class Contract
    {
        public string Id { get; set; }
        public string NumberOfProducts { get; set; }
    }
