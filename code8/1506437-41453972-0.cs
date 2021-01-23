    [Route("/customers/{" +  nameof(Id) + "}")]
    public class GetCustomer : IReturn<Customer>
    {
        public int Id { get; set; }
    }
    [Route("/customers/{" +  nameof(Id) + "}/transactions")]
    public class GetCustomerTransactions : IReturn<List<Transactions>>
    {
        public int Id { get; set; }
    }
