    public class TestValidator : TypeLevelAspect
    {
        public override bool CompileTimeValidate(Type type)
        {
            HashSet<string> propertyNames = new HashSet<string>();
    
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                JsonPropertyAttribute jsonProperty = (JsonPropertyAttribute)property.GetCustomAttribute(typeof(JsonPropertyAttribute));
    
                if (jsonProperty == null)
                    continue;
    
                if (!propertyNames.Add(jsonProperty.PropertyName))
                {
                    Message.Write(property, SeverityType.Error, "A01", "Duplicate JSON property {0} specified on {1}.",
                        jsonProperty.PropertyName, property);
                }
            }
    
            return false;
        }
    }
