    protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
    {
        if (entityEntry != null && entityEntry.State == EntityState.Added)
        {
            var errors = new List<DbValidationError>();
            var user = entityEntry.Entity as ApplicationUser;
            //check for uniqueness of phone number
            if (user != null)
            {
                if (Users.Any(u => String.Equals(u.PhoneNumber, user.PhoneNumber)))
                {
                    errors.Add(new DbValidationError("User",user.PhoneNumber+" is already registered."));
                }
            }
        }
        return base.ValidateEntity(entityEntry, items); //check for uniqueness of user name and email and return result
    }
