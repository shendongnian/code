    public virtual T Get(object id)
    {
            var propertyName = "AddressId";
            
            //get all navigation properties defined for entity
            var navigationProps = _context.Model.FindEntityType(typeof(T)).GetNavigations();
            
            //turn those navigation properties into a string array
            var includeProperties = navigationProps.Select(p => p.PropertyInfo.Name).ToArray();
            
            //make parameter of type T
            var parameter = Expression.Parameter(typeof(T), "e");
            
            //create the lambda expression
            var predicateLeft = Expression.PropertyOrField(parameter, propertyName);
            var predicateRight = Expression.Constant(id);
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(predicateLeft, predicateRight), parameter);
            //get queryable
            var query = _context.Set<T>().AsQueryable();
            //apply Include method to the query multiple times
            query = includeProperties.Aggregate(query, Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include);
            //return first item in query
            return query.FirstOrDefault(predicate);
    }
