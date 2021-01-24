    public class Payment {
       public int Id { get; set; }
       [ForeignKey("ConsumptionId")] // point to the navigation property to the FK
       public Consumption Consumption { get; set; }
       public int ConsumptionId { get; set; }
    }
