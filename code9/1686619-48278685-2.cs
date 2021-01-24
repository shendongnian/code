    public static class EntityTypeBuilderExtensions
    {
        public static List<PropertyBuilder> AllProperties<T>(this EntityTypeBuilder<T> builder, Func<PropertyInfo, bool> filter = null) where T : class
        {
            var properties = typeof(T).GetProperties().AsEnumerable();
            if (filter != null) properties = properties.Where(x => filter(x));
            return properties.Select(x => builder.Property(x.PropertyType, x.Name)).ToList();
        }
    }
