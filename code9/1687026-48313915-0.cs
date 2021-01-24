    private static DataCollection<Entity> GetRoutingConditions(Guid _questionId, Guid _surveyId)
    {
    	// Find Routing conditions
    	QueryExpression routingConditionQuery = new QueryExpression
    	{
    		EntityName = "msdyn_responsecondition",
    		ColumnSet = new ColumnSet(true),
    		Criteria = new FilterExpression
    		{
    			Conditions =
    			{
    				new ConditionExpression
    				{
    					AttributeName = "msdyn_questionid",
    					Operator = ConditionOperator.Equal,
    					Values = {_questionId}
    				}
    			}
    		},
    		LinkEntities =
    		{
    			new LinkEntity
    			{
    				LinkFromEntityName = "msdyn_responsecondition",
    				LinkToEntityName = "msdyn_responserouting",
    				LinkFromAttributeName = "msdyn_responseroutingid",
    				LinkToAttributeName = "msdyn_responseroutingid",
    				LinkCriteria =
    				{
    					Filters =
    					{
    						new FilterExpression
    						{
    							FilterOperator = LogicalOperator.And,
    							Conditions =
    							{
    								new ConditionExpression("msdyn_surveyid", ConditionOperator.Equal, _surveyId)
    							}
    						}
    					}
    				}
    			}
    		}
    	};
    	return connection.service.RetrieveMultiple(routingConditionQuery).Entities;
    }
