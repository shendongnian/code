    public ICustomer Get(int id)
    {
       return db.Set<Customer>().Find(id);
    }
 
