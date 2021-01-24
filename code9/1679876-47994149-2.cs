    public void UpdateUser(User u)
    {      
        _context.Users.Attach(u);
        _context.Entry(u).State = EntityState.Modified;
        _context.SaveChanges();
    }
