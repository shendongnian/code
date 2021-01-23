     public static void Copy(object source, object target, ObjectMapperCopyValidator rules)
    {
        Dictionary<string, IGetterSetter> target_properties = ClassUtils.GetGetterSetters(target);
        Dictionary<string, IGetterSetter> source_properties = ClassUtils.GetMatchingGetterSetters(target_properties.Keys, source);
        foreach (var entry in source_properties)
        {
            var sourceProperty = entry.Value;
            var targetProperty = target_properties[entry.Key];
            // for now, match datatypes directly
            if (sourceProperty.DataType == targetProperty.DataType)
            {
                // if property not readable or writeable, skip
                if (!(sourceProperty.CanRead && targetProperty.CanWrite))
                {
                    continue;
                }
                var sourceValue = sourceProperty.GetValue(source);
                try
                {
                    if (rules.IsValid(sourceProperty, sourceValue))
                    {
                        targetProperty.SetValue(target, sourceValue);
                    }
                }
                catch (TargetException e)
                {
                    LOG.ErrorFormat("unable to set value {0} for property={1}, ex={2}", sourceValue, targetProperty, e);
                }
            }
        }
    }
