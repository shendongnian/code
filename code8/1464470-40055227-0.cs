    foreach (User user in users)
    {
      Job original = _context.Users.Where(x => x.id== user.id).AsNoTracking().FirstOrDefault();
      if (original != null)
      {                   
        original.Name = user.Nanme;
      }                      
    }
     _context.SaveChanges(); 
