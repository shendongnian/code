        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
            IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                var errors = new List<DbValidationError>();
                var user = entityEntry.Entity as TUser;
                //check for uniqueness of user name and email
                if (user != null)
                {
                    if (Users.Any(u => String.Equals(u.UserName, user.UserName)))
                    {
                        errors.Add(new DbValidationError("User",
                            String.Format(CultureInfo.CurrentCulture, IdentityResources.DuplicateUserName, user.UserName)));
                    }
                    if (RequireUniqueEmail && Users.Any(u => String.Equals(u.Email, user.Email)))
                    {
                        errors.Add(new DbValidationError("User",
                            String.Format(CultureInfo.CurrentCulture, IdentityResources.DuplicateEmail, user.Email)));
                    }
                }
                else
                {
                    var role = entityEntry.Entity as TRole;
                    //check for uniqueness of role name
                    if (role != null && Roles.Any(r => String.Equals(r.Name, role.Name)))
                    {
                        errors.Add(new DbValidationError("Role",
                            String.Format(CultureInfo.CurrentCulture, IdentityResources.RoleAlreadyExists, role.Name)));
                    }
                }
                if (errors.Any())
                {
                    return new DbEntityValidationResult(entityEntry, errors);
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }
