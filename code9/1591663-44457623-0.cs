    foreach (var attribute in entityDto.Attributes)
    {
        if (attribute.Value is Entity)
        {                                    
            entity[attribute.Key] = new EntityReference(((Entity)attribute.Value).LogicalName, ((Entity)attribute.Value).Id);
        }
        // Check if EntityDto...
    }
