    public CustomerRepository : IRepository<Customer>
    {
       /* other methods here */
       void Delete(Customer entity)
       {
          // No casting
          // query for entity.CustomerId;
       }
    }
