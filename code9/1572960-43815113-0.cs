    dynamic entity;
    Database.Users.FindAll(query)
                  .With(Database.Users.Addresses.As("Address"))
                  .LeftJoin(Entities.As("Entity"), out entity).On(Users.ParentEntityId == entity.EntityID)
                  .WithOne(entity)
                  .Select(Database.Users.UserID,
                          Database.Users.FirstName,
                          Database.Users.LastName);
