    public static class DbEntityEntryExtension
    {
        public static void ModifyTypes<T>(this DbEntityEntry dbEntityEntry, Func<T, T> method)
        {
            foreach (var propertyInfo in dbEntityEntry.Entity.GetType().GetTypeProperties().Where(p => p.PropertyType == typeof(T) && p.CanWrite))
            {
                propertyInfo.SetValue(dbEntityEntry.Entity, method(dbEntityEntry.CurrentValues.GetValue<T>(propertyInfo.Name)));
            }
        }
    }
