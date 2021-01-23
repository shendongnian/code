    public static class FastMemberExtensions
    {
        public static void AssignValueToProperty(this ObjectAccessor accessor, string propertyName, object value)
        {
            var index = propertyName.IndexOf('.');
            if (index == -1)
            {
                var targetType = Expression.Parameter(accessor.Target.GetType());
                var property = Expression.Property(targetType, propertyName);
                var type = property.Type;
                type = Nullable.GetUnderlyingType(type) ?? type;
                value = value == null ? GetDefault(type) : Convert.ChangeType(value, type);
                accessor[propertyName] = value;
            }
            else
            {
                accessor = ObjectAccessor.Create(accessor[propertyName.Substring(0, index)]);
                AssignValueToProperty(accessor, propertyName.Substring(index + 1), value);
            }
        }
        private static object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
