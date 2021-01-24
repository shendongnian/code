    static class QueryableExtensions
    {
        // returns true if PropertyInfo implements ICollection<...>
        public static bool ImplementsICollection(this PropertyInfo propertyInfo)
        {
             return propertyInfo.IsGenericType
                 && propertyInfo.GetGenericTypeDefinition() == typeof(ICollection<>);
        }
        // returns all readable & writable PropertyInfos of type T that implement ICollection<...>
        public static IEnumerable<PropertyInfo> CollectionProperties<T>()
        {
            return typeof(T).GetProperties()
                .Where(prop => prop.CanRead
                    && prop.CanWrite
                    && prop.PropertyType.ImplementICollection();
        }
        // given an IQueryable<T>, adds the Include of all ICollection<...> T has
        public static IQueryable<T> IncludeICollection<T>(IQueryable<T> query)
        {
             var iCollectionProperties = CollectionProperties<T>();
             foreach (var collectionProperty in collectionProperties)
             {
                  query = query.Include(prop.Name);
             }
             return query;
        }
        // given a IQueryable<T> and a T return the first T in the query with Id higher than T
        // for this we need to be sure every T has an IComparable property Id
        // so T should implement interface IId (see below)
        public T Next<T>(this IQueryable<T> query, T currentItem)
             where T : IId  // makes sure every T has aproperty Id
        {
             T nextElement = query
                 // keep only those DbSet items that have larger Ids:
                 .Where(item => currentItem.Id < item.Id)
                 // sort in ascending Id:
                 .OrderBy(item => item.Id
                 // keep only the first element of this sorted collection:
                 .FirstOrDefault();
            return T
        }
    }
