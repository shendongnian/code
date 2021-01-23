    public class Day
    {
      public Week.Week Week { get; set; }
      [Key] 
      [Column(Order = 2)] 
      public DayOfWeek DayOfWeek { get; set; }
      public virtual List<Class.Class> Classes { get; set; }
      [Key] 
      [Column(Order=1)] 
      // Helper for PK; EF will recognize this as the FK by convention
      public string WeekId { get; set; }
    }
