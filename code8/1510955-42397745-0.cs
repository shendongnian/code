    foreach (string propertyName in dbEntity.OriginalValues.PropertyNames)
    {
        if(!dbEntity.Entity.GetType().GetCustomAttributes(typeof(UnMappedAttribute), true).Any())
        {
             continue;
        }
        if (!Equals(dbEntity.OriginalValues.GetValue<object>(propertyName), dbEntity.CurrentValues.GetValue<object>(propertyName)))
        {
            //.....
        }
    }
