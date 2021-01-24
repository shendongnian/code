    public void UpdateUser(UserViewModel  u)
    {        
        // Get the entity first
        var user = GetUserDetails(u.Id);
        // Read the property values of view model object and assign to entity object
        user.Name = u.Name;
        user.Address = u.Address;
        //using entity framework to save
        _context.SaveChanges();
    }
