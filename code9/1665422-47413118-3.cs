    public void Update(Employees emp)
    {
        _context.Employees.Attach(emp);
        _context.Entry(emp).Property(a => a.name).IsModified = true;
        _context.SaveChanges();
    }
