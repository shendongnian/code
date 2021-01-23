    using (var context = new MyContext())
    {
        //retrieve object model
        ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
    
        //retrieve name types
        var nameTypes = objContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.OSpace);
        
        var connectionString = objContext.Connection.ConnectionString;
        var connection = new EntityConnection(connectionString);
        var workspace = connection.GetMetadataWorkspace();
    
        var entitySets = workspace.GetItems<EntityContainer>(DataSpace.SSpace).First().BaseEntitySets;
    
        for (int i = 0; i < nameTypes.Count; i++)
        {
            Type type = Type.GetType(nameTypes[i].FullName);
            string schema = entitySets[type.Name].MetadataProperties["Schema"].Value.ToString();   
        }
    }
