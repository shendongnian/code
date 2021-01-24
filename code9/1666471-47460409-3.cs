    public List<T> RetrieveMultipleByIds<T>(IOrganizationService service, string entityLogicalName, string[] columnSet, string idFieldName, string[] guids)
    {
         QueryExpression query = new QueryExpression(entityLogicalName);
         query.ColumnSet = new ColumnSet(columnSet);
         query.Criteria = new FilterExpression();
         query.Criteria.AddCondition(idFieldName, ConditionOperator.In, guids);
    	 var entityCollection = service.RetrieveMultiple(query);
         return entityCollection.Select(e => e.ToEntity<T>()).ToList();
    }
