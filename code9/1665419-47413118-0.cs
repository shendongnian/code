    public void Update(Employees emp)
    {
        _context.Employees.Attach(emp);
        _context.Entry(emp).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
