    public void Save(Customer customer)
    {
       var dalCustomer = context.Customers.FirstOrDefault(c => c.Id = entity.Id);
       if (dalCustomer == null)
       {
          dalCustomer = new Customer();
          context.Customers.Add(dalCustomer);
       }
       dalCustomer.Name = customer.Name;
       dalCustomer.CreatedAt = DateTime.Now;
       context.SaveChanges();
    }
