    MyEntity detached = new MyEntity();
    
    Type entityType = typeof(MyEntity);
    IEnumerable<PropertyInfo> properties = entityType 
        .GetProperties()
        // Exclude inherited and special properties:
        .Where( pi => pi.DeclaringType == entityType && !pi.IsSpecialName )
        // Exclude non-read/write properties:
        .Where( pi => pi.CanRead && pi.CanWrite )
        // Exclude non-scalar properties:
        .Where( pi => pi.PropertyType.IsPrimitive || pi.PropertyType == typeof(String) );
    foreach( PropertyInfo property in properties ) {
        
        Object value;
        if( dict.TryGetValue( property.Name, out value ) ) {
            
            property.SetValue( detached, value );
        }
    }
    MyDBContext dbContext = ...
    
    // Attach the entity:
    dbContext.TableName.Add( detached );
   
    // Execute the INSERT:
    dbContext.SaveChanges();
