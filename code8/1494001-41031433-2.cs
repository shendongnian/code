    public List<LocationViewModel> GetNearesBurgerJoints()
    {
    
            var result = (from b in _context.BurgerJoints
                          join l in _context.Locations on b.Id equals l.Id
                          select new LocationViewModel
                          {
                              b.Name,
                              b.Description,
                              l.Latitude,
                              l.Longitude
    
                          }).ToList();
    
    
            return result; 
    }
