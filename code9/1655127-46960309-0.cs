    public class CustomerService: ICustomerService
    {
      ICustomerDbService db;
      public CustomerService(ICustomerDbService customerDbService)
      {
         db = customerDbService;
      }
    
      public bool Validate(int customerId)
      {
        var customer = db.GetCustomer(customerId);
        return Validate(customer);
      }
    
      public void Process(int customerId)
      {
        var customer = db.GetCustomer(customerId);
        if(Validate(customer))
        {
          //do processing...
        }
      }
    
      private bool Validate(Customer customer, /*other args*/)
      {
        if(customer == null)
          return "Not found";
        //other processing with multiple(3-4) common variables 
      }
    }
