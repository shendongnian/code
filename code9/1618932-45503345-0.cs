    public class CustomerTransaction
    {
        public int Id { get; set; }
        public string TransactionNumber { get; set; }
        public Amount Amount { get; set; }
    }
 
    public class Amount
    {
         public decimal Value { get; }
         public Currency Currency { get; }
    }
