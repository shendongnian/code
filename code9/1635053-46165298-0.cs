    class IncludePublicFieldsPolicy : IDestructuringPolicy
    {
        public bool TryDestructure(
            object value,
            ILogEventPropertyValueFactory propertyValueFactory,
            out LogEventPropertyValue result)
        {
            if (!(value is SomeBaseType))
            {
                result = null;
                return false;
            }
            var fieldsWithValues = value.GetType().GetTypeInfo().DeclaredFields
                .Where(f => f.IsPublic)
                .Select(f => new LogEventProperty(f.Name,
                   propertyValueFactory.CreatePropertyValue(f.GetValue(value))));
            result = new StructureValue(fieldsWithValues);
            return true;
        }
    }
