    public static void FillValues<T>(this T target, T source)
    {
        FillValues(typeof(T), target, source);
    }
    private static void FillValues(Type type, object target, object source)
    {
        FillMissingProperties(type, target, source);
        FillMissingFields(type, target, source);
    }
    private static void FillMissingProperties(Type type, object target, object source)
    {
        var properties = type.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
        foreach (var prop in properties)
        {
            var targetValue = prop.GetValue(target, null);
            var defaultValue = prop.PropertyType.GetTypeInfo().IsValueType ? Activator.CreateInstance(prop.PropertyType) : null;
            if (targetValue == null || targetValue.Equals(defaultValue))
            {
                var sourceValue = prop.GetValue(source, null);
                prop.SetValue(target, sourceValue, null);
            }
            else if (targetValue != null && prop.PropertyType != typeof(string) && prop.PropertyType.GetTypeInfo().IsClass)
            {
                var sourceValue = prop.GetValue(source, null);
                FillValues(prop.PropertyType, targetValue, sourceValue);
            }
        }
    }
        
    private static void FillMissingFields(Type type, object target, object source)
    {
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            var targetValue = field.GetValue(target);
            var sourceValue = field.GetValue(source);
            var defaultValue = field.FieldType.GetTypeInfo().IsValueType ? Activator.CreateInstance(field.FieldType) : null;
            if (targetValue == null || targetValue.Equals(defaultValue))
            {
                field.SetValue(target, sourceValue);
            }
            else if(targetValue != null && field.FieldType  != typeof(string) && field.FieldType.GetTypeInfo().IsClass)
            {
                FillValues(field.FieldType, targetValue, sourceValue);
            }
        }
    }
