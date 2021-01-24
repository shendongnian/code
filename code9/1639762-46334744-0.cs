    //code - Entity property values are updated with new ones
    var newEntity= new Entity
    {
        Id = p.Id, // the Id you want to update
        Column1= ""  // put value for column/s that you need to update
    };
    newEntity.MapToModel(oldEntity);
    _dbContext.SaveChanges();
