    public void AddRecord(int customerId)
    {
        //First get the Customer object. This is an example, modify to your actual code
        Customer customer = GetCustomer(customerId);
        IEnumerable<Attributes> Attributes = GetAttributes();
        foreach (var attribute in Attributes)
        {
            _context.Add(new MainTable
            {
                 Customer = customer,
                 Attribute1 = attribute
            });
        }
        _context.SaveChanges();
    }
