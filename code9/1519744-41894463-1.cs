    public enum Status
    {
      SomeStatusA = 1,
      SomeStatusB = 2,
      SomeStatusC = 3,
    }
    public class Position: EntityBase
    {
       public Status Status { get; set; }
       public string ReferenceCode { get; set; }
       public string Location { get; set; }
       public string Content { get; set; }
    }
