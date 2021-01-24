    public class Consumption 
    {
       public int Id { get; set; }
       ...
       [ForeignKey("ConsumptionId")]  // Point to the dependent FK
       public virtual List<Payment> Payments { get; set; }
    }
