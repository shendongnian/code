    public class ClubSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GetCustomerResponse
    {
        public Customer Customer { get; set; }
        public List<ClubSummary> Clubs { get; set; }
    }
