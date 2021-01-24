    public static class Extensions
    {
        private static readonly Dictionary<Type, string> NewIdDictionary = new Dictionary<Type, string>
        {
            { typeof(SqlServerOptionsExtension), "newid()" }
        };
        public static PropertyBuilder<TProperty> HasDefaultValueForSql<TProperty>(this PropertyBuilder<TProperty> propertyBuilder, 
            DbContextOptions contextOptions)
        {
            var result = contextOptions.Extensions.Select(extension =>
            {
                if (!(extension is RelationalOptionsExtension item)) return string.Empty;
                return NewIdDictionary.TryGetValue(item.GetType(), out var sql) ? sql : string.Empty;
            }).SingleOrDefault(s => !string.IsNullOrEmpty(s));
            return propertyBuilder.HasDefaultValueSql(result);
        }
    }
