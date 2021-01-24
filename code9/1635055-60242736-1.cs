    internal class IncludePublicFieldsPolicy : IDestructuringPolicy
    {
        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
        {
            var typeInfo = value.GetType().GetTypeInfo();
    
            var fieldsWithValues = typeInfo
                .DeclaredFields
                .Where(f => f.IsPublic)
                .Select(f =>
                {
                    var val = f.GetValue(value);
                    var propval = propertyValueFactory.CreatePropertyValue(val);
                    var ret = new LogEventProperty(f.Name, propval);
                    return ret;
                })
            ;
    
            var propertiesWithValues = typeInfo
                .DeclaredProperties
                .Where(f => f.CanRead)
                .Select(f =>
                {
                    var val = f.GetValue(value);
                    var propval = propertyValueFactory.CreatePropertyValue(val);
                    var ret = new LogEventProperty(f.Name, propval);
                    return ret;
                })
            ;
    
            result = new StructureValue(fieldsWithValues.Union(propertiesWithValues));
            return true;
        }
    }
