    if (auditableEntity.CurrentValues.PropertyNames.Contains(nameof(IAuditable.CreatedDate)))
        auditableEntity.Property(p => p.CreatedDate).IsModified = false;
    if (auditableEntity.CurrentValues.PropertyNames.Contains(nameof(IAuditable.CreatedBy)))
        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
 
