    [Route("/customers/search")]
    public class SearchCustomers : QueryDb<Customer>
    {
        public int[] CustomerIds { get; set; }
        public long[] CardNumbers { get; set; }
        public string[] Emails { get; set; }
    }
