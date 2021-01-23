        // Defines some constants
        const string userName = "James";
        var userGuid = Guid.NewGuid();
        // Create a user
        using (var userContext = new UserContext())
        {
            userContext.Users.Add(new User { Name = userName, Id = userGuid });
            userContext.SaveChanges();
        }
        // Create a building linked to a user
        using (var buildingContext = new BuildingContext())
        {
            var userReference = buildingContext.Users.First(user => user.Id == userGuid);
            buildingContext.Buildings.Add(new Building { Id = Guid.NewGuid(), Location = "Switzerland", User = userReference });
            buildingContext.SaveChanges();
        }
