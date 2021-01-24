    public class Payment {
       public int Id { get; set; }
       public Consumption Consumption { get; set; }
       [ForeignKey("Consumption")] // point to the FK to the navigation property
       public int ConsumptionId { get; set; }
    }
