    if (dest.PropertyHasCustomAttribute(propertyInfo.Name, typeof(EntityChildCollectionAttribute)))
    {
        var source = propertyInfo.GetValue(original, null) as IList;
        var target = propertyInfo.GetValue(dest, null) as IList;
        foreach (dynamic sourceEntity in source)
        {
            var found = false;
            object targetEntity = null;
            foreach (dynamic tEntity in target)
            {
                if (sourceEntity.IdentityGuid != tEntity.IdentityGuid) continue;
                found = true;
                targetEntity = tEntity;
                break;
            }
            if (!found)
            {
                var b = propertyInfo.PropertyType.GetGenericArguments()[0];
                targetEntity = Activator.CreateInstance(b);
            }
                            
            sourceEntity.CloneMeToProvidedEntity(targetEntity);
            if (!found)
            {
                target.Add(targetEntity);
            }
        }
    }
