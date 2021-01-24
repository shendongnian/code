    public class Customer
    {
      private Customer() { }
      public Customer(int id) { /* only sets id */ }
      public Customer(int id, string name) { /* ...populate properties... */ }
      public int Id { get; private set; }
      public string Name { get; private set; }
      // and so on...
      
      public void SetName(string name)
      {
          //set name, perhaps check for condition first
      }
    }
    public class MyController
    {
        var customer = new Customer(getIdFromSomewhere());
        myContext.Set<Customer>().Attach(customer);
        order.setCustomer(customer);
        myContext.SaveChanges(); //sets the customer to order and saves it, without actually changing customer: still read as unchanged.
    }
