    public class TransactionRecurrence 
    {
      public int DurationPerMonth { get; set; }
    }
    public class Transaction
    {
      public TransactionRecurrence _transref;
      public Transaction(TransactionRecurrence transref)
    {
      _transref = transref;
    }
    //other properties
    }
