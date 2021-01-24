    public CellSet GetMdxSetOnColumns(string setExpression)
    {
        var connectionString = "replace with your connection string";
        // The query parameter @TheSet will be replaced with setExpression.
        var query = "SELECT StrToSet(@TheSet) ON 0 FROM [Adventure Works]";
        
        // Add the passed in string as a query parameter.
        var parms = new Dictionary<string, object>();
        // You can omit the "@" in front of the parameter name here.
        parms.Add("TheSet", setExpression);
        return GetCellSet(connectionString, query, parms);
    }
