    public List<CustomUser> GetActiveCustomuser()
    {
        return context.Users
           .Where(u => u.Active)
           .Select(new CustomUser() 
               { 
                   Name = u.Name, 
                   Place = new CustomPlace() { Name = u.Place.Name }
               });
    }
