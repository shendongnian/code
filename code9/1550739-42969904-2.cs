    public CustomerRepository : IRepository
    {
       /* other methods here */
       void Delete(BaseEntity entity)
       {
          var customer = entity as Customer;
          // query for customer.CustomerId;
       }
    }
