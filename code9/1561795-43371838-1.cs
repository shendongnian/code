    public class Person
    {
      public int PersonId { get; set; }
      public string Name { get; set; }
      public int CarId { get; set; }
      public virtual Car Car { get; set; }
    }
    
    public class Car
    {
      public int CarId { get; set; }
      public string LicensePlate { get; set; }
      public int PersonId { get; set; }
      public virtual Person Person { get; set; }
    }
      
