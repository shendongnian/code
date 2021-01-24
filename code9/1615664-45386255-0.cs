    // We don't support set only, non public, or indexer properties
    if (property.GetMethod == null ||
       !property.GetMethod.IsPublic ||
       property.GetMethod.GetParameters().Length > 0)
    {
       return;
    }
