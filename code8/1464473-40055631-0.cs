    foreach (var usr in users)
    {
        var user = new User { Id = usr.Id, Name = usr.Name };
        _context.Users.Attach(user);
        _context.Entry(user).Property(x => x.Name).IsModified = true;
    }
    
    _context.SaveChanges();
