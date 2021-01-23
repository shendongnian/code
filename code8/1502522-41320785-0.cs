    using (TestContext tEntities = new TestContext())
    {
        var filterExp = Exp.ExpressionBuilder.GetExpression<Client>(filters);
        var filteredCollection = tEntities.Client.Where(filterExp);
    
        IQueryable<Client> queryResult = tEntities.Client;
        if (filterExp != null)
        {
            queryResult = queryResult.Where(filterExp);
        }
        //do something else with queryResult
    }
