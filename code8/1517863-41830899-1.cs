    private Expression<Func<Dictionary<string, object>, bool>> 
                         GenerateWhereExpression(Dictionary<string, object> filterParams)
    {
    	var pe = Expression.Parameter(typeof(Dictionary<string, object>), "x");
        // it is call of x.getItem("name") what is the same as x["name"]
    	var dictPropery = Expression.Call(pe, 
               typeof(Dictionary<string, object>).GetMethod("get_Item"), 
               Expression.Constant("name")); 
        
        //cast to ((string)x.getItem("name"))
    	var castProperty = Expression.Convert(dictPropery, typeof(string));
    	var methodCall = Expression.Call(castProperty, 
                        typeof(string).GetMethod("Contains"), 
                        Expression.Constant(filterParams["name"], typeof(string)));
    	var lambda = Expression.Lambda<Func<Dictionary<string, object>, bool>>(methodCall, pe);
    	return lambda;
    }
