    public static class DbContextHelper
    {
        public static Func<IQueryable<T>, IQueryable<T>> GetNavigations<T>() where T : BaseEntity
        {
            var type = typeof(T);
            var navigationProperties = new List<string>();
            //get navigation properties
            GetNavigationProperties(type, type, string.Empty, navigationProperties);
            Func<IQueryable<T>, IQueryable<T>> includes = ( query => {
                        return  navigationProperties.Aggregate(query, (current, inc) => current.Include(inc));   
                });
            return includes;
        }
        private static void GetNavigationProperties(Type baseType, Type type, string parentPropertyName, IList<string> accumulator)
        {
            //get navigation properties
            var properties = type.GetProperties();
            var navigationPropertyInfoList = properties.Where(prop => prop.IsDefined(typeof(NavigationPropertyAttribute)));
            foreach (PropertyInfo prop in navigationPropertyInfoList)
            {
                var propertyType = prop.PropertyType;
                var elementType = propertyType.GetTypeInfo().IsGenericType ? propertyType.GetGenericArguments()[0] : propertyType;
                //Prepare navigation property in {parentPropertyName}.{propertyName} format and push into accumulator
                var properyName = string.Format("{0}{1}{2}", parentPropertyName, string.IsNullOrEmpty(parentPropertyName) ? string.Empty : ".", prop.Name);
                accumulator.Add(properyName);
                //Skip recursion of propert has JsonIgnore attribute or current property type is the same as baseType
                var isJsonIgnored = prop.IsDefined(typeof(JsonIgnoreAttribute));
                if(!isJsonIgnored && elementType != baseType){
                    GetNavigationProperties(baseType, elementType, properyName, accumulator);
                }
            }
        }
    }
