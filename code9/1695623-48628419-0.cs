    public interface IHasKeyProperty
    {
      int Key { get; set; }
    }
    
    public class Manager : IHasKeyProperty
    {
      public int Key { get; set; }
    
      // Rest of manager code...
    }
    
    public class Employee : IHasKeyProperty
    {
      public int Key { get; set; }
    
      // Rest of employee code...
    }
