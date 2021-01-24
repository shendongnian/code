    public virtual void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
    {
        //Ensure only modified fields are updated.
        var dbEntityEntry = DbContext.Entry(entity);
        if (updatedProperties.Any())
        {
            //update explicitly mentioned properties
            foreach (var property in updatedProperties)
            {
                dbEntityEntry.Property(property).IsModified = true;
            }
        }
        else{
            //no items mentioned, so find out the updated entries
            foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
            {
                var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                if (original != null && !original.Equals(current))
                    dbEntityEntry.Property(property).IsModified = true;
            }
        }
    }
