    public class Order2 {
      public long orderId { get; set; }
      public string orderStatusCode { get; set; }
      public string orderStatusDescription { get; set; }
      public int serviceProviderId { get; set; }
      public string orderOpeningDate { get; set; }
      public string orderSchedulingDate { get; set; }
      public string orderSchedulingPeriod { get; set; }
      public object orderSettlementDate { get; set; }
      public object orderCancellationDate { get; set; }
    }
    public class Order{
      public Order2 order { get; set; }
    }
    public class RootObject{
      public List<Order> orders { get; set; }
    }
