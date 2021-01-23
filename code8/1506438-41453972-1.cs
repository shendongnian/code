    [Route("/customers")]
    public class GetCustomers : IReturn<List<Customer>>
    {
        public int[] CustomerIds { get; set; }
        public long[] CardNumbers { get; set; }
        public string[] Emails { get; set; }
    }
