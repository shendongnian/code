    public void AddRecord(Customer customer)
    {
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
