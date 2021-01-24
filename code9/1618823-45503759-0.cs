    internal string[] excludedPropertiesInUpdate = new[] { "CreatedDate", "CreatedBy" };
    public void Update(T entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        var entry = _context.Entry(entity);
       entry.State = EntityState.Modified;
        //Restrict Modification for Specified Properties
        foreach(string propertyName in excludedPropertiesInUpdate)
        {
            entry.Property(propertyName).IsModified = false;   
        }
        //load actual values from the database.
        entry.Reload(); 
    }
