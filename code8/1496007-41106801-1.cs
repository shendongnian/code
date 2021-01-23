    class MyEntity : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Address1)
                && string.IsNullOrEmpty(Address2)
                && string.IsNullOrEmpty(AddressFull))
            {
                yield return new ValidationResult("An address is required.");
            }
        }
    }
    class MyContext : DbContext
    {
        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }
            return base.SaveChanges();
        }
    }
