    [Route("/customer/{Id}", "GET")]
    public class GetCustomer : IReturn<GetCustomerResponse>
    {
        public int Id { get; set; }
    }
    public class GetCustomerResponse
    {
        public Customer Customer { get; set; }
        public List<Club> Clubs { get; set; }
    }
