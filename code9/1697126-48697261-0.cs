    public class Consumption 
    {
       public int Id { get; set; }
       ...
       public virtual List<Payment> Payments { get; set; }
    }
    public class Payment {
       public int Id { get; set; }
       public Consumption Consumption { get; set; }
       public int ConsumptionId { get; set; }
    }
