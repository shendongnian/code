    public void UpdateUser(UserEntity entity)
    {
        // Load the exiting entity from the db, including the collection
        var dbEntity = this.dataContext.Users
            .Include(e => e.DepartmentUnits)
            .FirstOrDefault(e => e.Id == entity.Id);
        if (dbEntity == null)
            throw new NullReferenceException("User not found");
        // Update the master information
        this.dataContext.Entry(dbEntity).CurrentValues.SetValues(entity);
        // Replace the collection with stubs created from the source collection
        dbEntity.DepartmentUnits = entity.DepartmentUnits.Select(e => new UnitEntity { Id = e.Id }).ToList();
        // And that's all - EF change tracker will detect added/removed/unchanged links (and changed master properties) for you.
        // Just commit the changes and you are done.
        this.dataContext.SaveChanges();
    }
