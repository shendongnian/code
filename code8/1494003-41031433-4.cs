    public List<LocationViewModel> GetNearesBurgerJoints()
    {
    
            var result = (from b in _context.BurgerJoints
                          join l in _context.Locations on b.Id equals l.Id
                          select new LocationViewModel
                          {
                              Name = b.Name,
                              Description = b.Description,
                              Latitude = l.Latitude,
                              Longitude = l.Longitude
    
                          }).ToList();
    
    
            return result; 
    }
