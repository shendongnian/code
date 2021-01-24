    using (var dbConnection = new MyDbConnection())
    {
        var requestedOwners = dbConnection.Owners              // Give me all Owners
            .Where(owner => !owner.Pets.Any()                  // that have no Pets at all
              || owner.Pets.All(pet => pet.Status == Active)); // or have only active Pets
    }
