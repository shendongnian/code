    /// <summary>
    /// Retrieves the subset of entities in a table exposed through OData
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="U">Subset type</typeparam>
    /// <param name="query"></param>
    /// <param name="Set"></param>
    /// <param name="propertyExpression"></param>
    /// <returns></returns>
    public static DataServiceQuery<T> SubSet<T, U>(
    	this DataServiceQuery<T> query, 
    	IEnumerable<U> Set, 
    	Expression<Func<T, U>> propertyExpression)
    {
    	//The Filter Predicate that contains the Filter criteria
    	Expression filterPredicate = null;
    	//The parameter expression containing the Entity Type
    	var param = propertyExpression.Parameters.Single();
    	//Get Key Property 
    	//The Left Hand Side of the Filter Expression
    	var left = propertyExpression.Body;
    	//Build a Dynamic Linq Query for finding an entity whose ID is in the list
    	foreach (var id in Set)
    	{
    		//Build a comparision expression which equats the Id of the Entity with this value in the IDs list
    		// ex : e.Id == 1
    		Expression comparison = Expression.Equal(left, Expression.Constant(id));
    		//Add this to the complete Filter Expression
    		// e.Id == 1 or e.Id == 3
    		filterPredicate = (filterPredicate == null) 
    			? comparison 
    			: Expression.Or(filterPredicate, comparison);
    	}
    
    	//Convert the Filter Expression into a Lambda expression of type Func<Lists,bool>
    	// which means that this lambda expression takes an instance of type EntityType and returns a Bool
    	var filterLambdaExpression = 
    		Expression.Lambda<Func<T, bool>>(filterPredicate, param);
    	return (DataServiceQuery<T>)query.Where<T>(filterLambdaExpression);
    }
