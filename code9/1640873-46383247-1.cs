        public static class DbContextHelper
            {
        
        public static Includes<T> GetNavigations<T>() where T : BaseEntity
                {
                    Includes<T> includes = null;
                    var type = typeof(T);
        
                    //get navigation properties
                    var properties = type.GetProperties();
                    var navigationPropertyInfoList = properties.Where(prop => prop.IsDefined(typeof(NavigationPropertyAttribute)));
        
                    var navigationProperties = new List<Navigation>();
                    //Get first and second level navigation properties 
                    foreach (PropertyInfo prop in navigationPropertyInfoList)
                    {
                        var propertyType = prop.PropertyType;
                        var navigation = new Navigation()
                        {
                            NavigationProperty = prop.Name
                        };
                        var elementType = propertyType.GetTypeInfo().IsGenericType ? propertyType.GetGenericArguments()[0] : propertyType;
                        var internalNav = elementType.GetProperties()
                                        .Where(p => p.IsDefined(typeof(NavigationPropertyAttribute)));
        
                        navigation.InternalNavigationProperties = internalNav.Select(i => i.Name).ToList();
                        navigationProperties.Add(navigation);
                    }
        
                    if (navigationProperties != null && navigationProperties.Count != 0)
                    {
                        includes = new Includes<T>(query =>
                        {
                            return query.IncludeNavigation(navigationProperties);
                        });
                    }
        
                    return includes;
                }
    
    public static IQueryable<T> IncludeNavigation<T>(this IQueryable<T> query, IList<Navigation> navigationProperties)
            where T : BaseEntity
            {
                foreach (var property in navigationProperties)
                {
                    //apply first-level navigation
                    //Equivalent to Include
                    query = query.Include(property.NavigationProperty);
                    if (property.InternalNavigationProperties != null)
                    {
                        foreach (string iprop in property.InternalNavigationProperties)
                        {
                            //apply second-level navigation using dot operator
                            //Equivalent to ThenInclude
                            query = query.Include($"{property.NavigationProperty}.{iprop}");
                        }
                    }
                }
                return query;
            }
    
    
        }
