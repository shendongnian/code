    var entityType = auditableEntity.Entity.GetType();
    var dbSet = Set(entityType);
    var newEntity = (ISomething)dbSet.Create();
    //ISomething known properties.
    newEntity.propX = "1";
    newEntity.propY = "2";
    dbSet.Add(newEntity); 
 
