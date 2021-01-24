    entities.StagingViolation.AddRange(violations.Select(violation => {
            var newViolation = new StagingViolation();
            typeof(StagingViolation).GetProperties().Where(property => property.PropertyType.IsSimpleType())
                        .ToList()
                        .ForEach(property => {
                            typeof(StagingViolation).GetProperty(property.Name).SetValue(newViolation, property.GetValue(violation, null));
        });
        newViolation.ProcessingId = newProcessingId;
        return newViolation;
    }));
    public static class TypeExtension {
        public static bool IsSimpleType(this Type type) {
            while (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                type = type.GetGenericArguments()[0];
            }
            return type.IsValueType || type.IsPrimitive || new[] { typeof(string), typeof(decimal), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan), typeof(Guid) }.Contains(type) || Convert.GetTypeCode(type) != TypeCode.Object;          
        }
    }
