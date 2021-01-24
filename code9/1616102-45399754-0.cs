    static EntitySet GetStorageEntitySet(ObjectContext objectContext, Type clrEntityType)
    { 
    	var metadata = objectContext.MetadataWorkspace;
    
    	// Get the part of the model that contains info about the actual CLR types
    	var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));
    
    	// Get the entity type from the model that maps to the CLR type
    	var entityType = metadata
    			.GetItems<EntityType>(DataSpace.OSpace)
    				  .Single(e => objectItemCollection.GetClrType(e) == clrEntityType);
    
    	// Get the entity set that uses this entity type
    	var entitySet = metadata
    		.GetItems<EntityContainer>(DataSpace.CSpace)
    			  .Single()
    			  .EntitySets
    			  .Single(s => s.ElementType.Name == entityType.Name);
    
    	// Find the mapping between conceptual and storage model for this entity set
    	var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
    		.Single()
    		.EntitySetMappings
    		.Single(s => s.EntitySet == entitySet);
    
    	// Find the storage entity set (table) that the entity is mapped
    	return mapping
    		.EntityTypeMappings.Single()
    		.Fragments.Single()
    		.StoreEntitySet;
    }
