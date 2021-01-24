    Query q = context.InputParameters.TryGetValue("Query") as QueryExpression; // could also be QueryByAttribute or FetchExpression,
    if (q != null)
    {
       ColumnSet cols = q.ColumnSet;
       if (cols.AllColumns == true || cols.Columns.Contains("regarding_object_type"))
       {    
           executionContext.OutputParameters["BusinessEntityCollection"] = GetResultValuesInWhateverWayYouAreGoingTo(); 
       }
    }
