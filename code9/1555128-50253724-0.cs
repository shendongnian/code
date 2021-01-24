        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var res =  base.ValidateEntity(entityEntry, items);
            //hack to convince EF that AspNetRole.Name does not need to be unique
            if (!res.IsValid
                && entityEntry.Entity is ApplicationRole
                && entityEntry.State == EntityState.Added
                && res.ValidationErrors.Count == 1
                && res.ValidationErrors.First().PropertyName == "Role")
            {
                return new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
            }
            return res;
        }
