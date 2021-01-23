        // make the generic type for the given entity type using the generic definition
        var entityConfigType = typeof(EntityTypeConfiguration<>).MakeGenericType(new Type[] { entityType });
        
        // instantiate the entity type configuration
        var obj = Activator.CreateInstance(entityConfigType);
        
        // get and make a generic method to invoke with the object above. Check the binding flags if it doesn't find the method
        var methodDef = typeof(Extensions).GetMethod("AddConfiguration", BindingFlags.Static | BindingFlags.Public);
        var method = methodDef.MakeGenericMethod(new Type[] { entityConfigType });
        
        // and finally the end goal
        method.Invoke(null, new object[] { builder, obj });
    }
