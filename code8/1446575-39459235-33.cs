    // Defines some constants
    const string userName = "James";
    var userGuid = Guid.NewGuid();
    
    // Initialize the db
    using (var db = new DatabaseContext())
    {
        db.Database.Initialize(true);
    }
    
    // Create a user
    using (var userContext = new UserContext())
    {
        userContext.Users.Add(new User {Name = userName, Id = userGuid});
        userContext.SaveChanges();
    }
    
    // Create a building linked to a user
    using (var buildingContext = new BuildingContext())
    {
        buildingContext.Buildings.Add(new Building {Id = Guid.NewGuid(), Location = "Switzerland", UserId = userGuid});
        buildingContext.SaveChanges();
    }
