    QueryExpression opportunityProductsQuery = new QueryExpression
    {
        EntityName = PCSEPortal.oph_ophthalmicclaim.EntityLogicalName,
        TopCount = 1,
        ColumnSet = new ColumnSet("Name")...
    };
