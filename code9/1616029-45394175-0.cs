    static Main()
    {
      var person = new Person { Age = 21 };
      var bartender = new Bartender(person);
      if (bartender.CanServeAlcohol())
      {
      }
    }
    public interface ICustomer
    {
      int Age { get; } 
      // Ideally this should be a DateTime with a function
      // that returns the age, so this is really just an example
    }
    public class Customer : ICustomer
    {
      public int Age { get; set; }
    }
    public class Bartender
    {
      public ICustomer _customer;
      public Bartender(ICustomer customer)
      {
        _customer = customer;
      }
      public bool CanServeAlcohol()
      {
        return _customer.Age >= 21;
      }
    }
