    foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
    {
        var ignore = Attribute.IsDefined(auditableEntity.Entity.GetType().GetProperty("CreatedDate"), typeof(NotMappedAttribute))
        if (!ignore) {
            auditableEntity.Entity.CreatedDate = dateTimeNow;
        }
    }
