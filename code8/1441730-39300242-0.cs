    public static class ObjectUtils
    {
        public static IEnumerable<PropertyInfo> GetPropertiesByType<TEntity>(TEntity entity, Type type)
            {
                return entity.GetType().GetProperties().Where(p => p.PropertyType == type); 
            }
    
        public static bool CheckAllStringProperties<TEntity>(TEntity instance, IEnumerable<PropertyInfo> stringProperties, string word)
            {
                return stringProperties.Select(x => (string)x.GetValue(instance, null))
                    .Where(x => x != null)
                    .Any(x => x.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
    }
