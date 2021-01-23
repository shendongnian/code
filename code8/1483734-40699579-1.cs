    public static T MapProperties<T>(object source)
    {
        return (T)MapProperties(source, typeof(T));
    }
    public static object MapProperties(object source, Type targetType)
    {
        object target = Activator.CreateInstance(targetType, nonPublic: false);
        Type sourceType = source.GetType();
        var sourcePropertyLookup = sourceType.GetProperties().ToDictionary(p => p.Name);
        var targetPropertyLookup = targetType.GetProperties().ToDictionary(p => p.Name);
        var commonProperties = targetPropertyLookup.Keys.Intersect(sourcePropertyLookup.Keys);
        foreach (var commonProp in commonProperties)
        {
            PropertyInfo sourceProp = sourcePropertyLookup[commonProp];
            PropertyInfo targetProp = targetPropertyLookup[commonProp];
            object sourcePropValue = sourceProp.GetValue(source);
            if(sourcePropValue == null || targetProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
            {
                targetProp.SetValue(target, sourceProp.GetValue(source));
            }
            else
            {
                object mappedValue = MapProperties(sourceProp.GetValue(source), targetProp.PropertyType);
                targetProp.SetValue(target, mappedValue);
            }
        }
        return target;
    }
