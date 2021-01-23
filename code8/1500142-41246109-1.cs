    public IQueryable<Customer> Customers =>
        Set<Customer>.Where(n => n.Active == true);
    public IQueryable<Contact> Contacts =>
        Set<Contact>.Where(n => n.Active == true);
    
