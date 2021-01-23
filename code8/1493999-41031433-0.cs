     public List<Location> GetNearesBurgerJoints()
        {
    
            var result = (from b in _context.BurgerJoints
                          join l in _context.Locations on b.Id equals l.Id
                          select new Location
                          {
                              b.Name,
                              b.Description,
                              l.Latitude,
                              l.Longitude
    
                          }).ToList();
    
    
            return result; 
    }
