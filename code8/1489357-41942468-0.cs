    /// <summary>
    /// A helper class for managing custom behaviors of Mockable database contexts
    /// </summary>
    public static partial class EFSaveChangesBehaviors
    {
        /// <summary>
        /// Enable auto-incrementing of primary key values upon SaveChanges/SaveChangesAsync
        /// </summary>
        /// <typeparam name="T">The type of context to enable auto-incrementing on</typeparam>
        /// <param name="context">The context to enable this feature</param>
        public static void EnableAutoIncrementOnSave<T>(this Mock<T> context) where T : DbContext
        {
            context.Setup(m => m.SaveChangesAsync())
                .Callback(() =>
                {
                    EFSaveChangesBehaviors.SaveChangesIncrementKey(context.Object);
                })
                .Returns(() => Task.Run(() => { return 1; }))
                .Verifiable();
            context.Setup(m => m.SaveChanges())
                .Callback(() =>
                {
                    EFSaveChangesBehaviors.SaveChangesIncrementKey(context.Object);
                })
                .Returns(() => { return 1; })
                .Verifiable();
        }
        /// <summary>
        /// Implements key incrementing of data records that are pending to be added to the context
        /// </summary>
        /// <param name="context"></param>
        public static void SaveChangesIncrementKey(DbContext context)
        {
            var tablesWithNewData = GetUnsavedRows<DbContext>(context);
            for (int i = 0; i < tablesWithNewData.Count; i++)
            {
                long nextPrimaryKeyValue = 0;
                var tableWithDataProperty = tablesWithNewData[i];
                var tableWithDataObject = tableWithDataProperty.GetValue(context);
                if (tableWithDataObject != null)
                {
                    var tableWithDataQueryable = tableWithDataObject as IQueryable<object>;
                    // 1) get the highest value in the DbSet<> (table) to continue auto-increment from
                    nextPrimaryKeyValue = IterateAndPerformAction(context, tableWithDataQueryable, tableWithDataProperty, nextPrimaryKeyValue, (primaryExistingKeyValue, primaryKeyRowObject, primaryKeyProperty) =>
                    {
                        if (primaryExistingKeyValue > nextPrimaryKeyValue)
                            nextPrimaryKeyValue = Convert.ToInt64(primaryExistingKeyValue);
                        return nextPrimaryKeyValue;
                    });
                    // 2) increase the value of the record's primary key on each iteration
                    IterateAndPerformAction(context, tableWithDataQueryable, tableWithDataProperty, nextPrimaryKeyValue, (primaryKeyExistingValue, primaryKeyRowObject, primaryKeyProperty) =>
                    {
                        if (primaryKeyExistingValue == 0)
                        {
                            nextPrimaryKeyValue++;
                            Type propertyType = primaryKeyProperty.PropertyType;
                            if (propertyType == typeof(Int64))
                                primaryKeyProperty.SetValue(primaryKeyRowObject, nextPrimaryKeyValue);
                            else if (propertyType == typeof(Int32))
                                primaryKeyProperty.SetValue(primaryKeyRowObject, Convert.ToInt32(nextPrimaryKeyValue));
                            else if (propertyType == typeof(Int16))
                                primaryKeyProperty.SetValue(primaryKeyRowObject, Convert.ToInt16(nextPrimaryKeyValue));
                            else if (propertyType == typeof(byte))
                                primaryKeyProperty.SetValue(primaryKeyRowObject, Convert.ToByte(nextPrimaryKeyValue));
                            else
                                throw new System.NotImplementedException($"Cannot manage primary keys of type: {propertyType.FullName}");
                        }
                        return nextPrimaryKeyValue;
                    });
                }
            }
        }
        /// <summary>
        /// Get a list of properties for a data table that are indicated as a primary key
        /// </summary>
        /// <param name="t"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <remarks>Reflection must be used, as the ObjectContext is not mockable</remarks>
        public static PropertyInfo[] GetPrimaryKeyNamesUsingReflection(Type t, DbContext context)
        {
            var properties = t.GetProperties();
            var keyNames = properties
                .Where(prop => Attribute.IsDefined(prop, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)))
                .ToArray();
            return keyNames;
        }
        /// <summary>
        /// Iterates a table's data and allows an action to be performed on each row
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="tableWithDataQueryable"></param>
        /// <param name="tableWithDataProperty"></param>
        /// <param name="nextPrimaryKeyValue"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private static long IterateAndPerformAction(DbContext context, IQueryable<object> tableWithDataQueryable, PropertyInfo tableWithDataProperty, long nextPrimaryKeyValue, Func<long, object, PropertyInfo, long> action)
        {
            foreach (var primaryKeyRowObject in tableWithDataQueryable)
            {
                // create a primary key for the object
                if (tableWithDataProperty.PropertyType.GenericTypeArguments.Length > 0)
                {
                    var dbSetType = tableWithDataProperty.PropertyType.GenericTypeArguments[0];
                    // find the primary key property
                    var primaryKeyProperty = GetPrimaryKeyNamesUsingReflection(dbSetType, context).FirstOrDefault();
                    if (primaryKeyProperty != null)
                    {
                        var primaryKeyValue = primaryKeyProperty.GetValue(primaryKeyRowObject) ?? 0L;
                        nextPrimaryKeyValue = action(Convert.ToInt64(primaryKeyValue), primaryKeyRowObject, primaryKeyProperty);
                    }
                }
            }
            return nextPrimaryKeyValue;
        }
        /// <summary>
        /// Get a list of objects which are pending to be added to the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IList<PropertyInfo> GetUnsavedRows<T>(T context)
        {
            // get list of properties of type DbSet<>
            var dbSetProperties = new List<PropertyInfo>();
            var properties = context.GetType().GetProperties();
            foreach (var property in properties)
            {
                var setType = property.PropertyType;
                var isDbSet = setType.IsGenericType && (typeof(IDbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()) || setType.GetInterface(typeof(IDbSet<>).FullName) != null);
                if (isDbSet)
                {
                    dbSetProperties.Add(property);
                }
            }
            return dbSetProperties;
        }
        
    }
