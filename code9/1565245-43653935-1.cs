    public class Customer
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    
      [NotMapped]
      [Computed]
      public string FullName
      {
        get { return FirstName + " " + LastName; }
      }
    }
    var customers = ctx.Customers
      .Select(c => new
      {
        FullName = c.FullName
      })
      .Decompile();
