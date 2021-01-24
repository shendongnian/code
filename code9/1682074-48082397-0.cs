    LinkEntity userRoles = new LinkEntity
    {
    	LinkFromEntityName = "role",
    	LinkToEntityName = "systemuserroles",
    	LinkFromAttributeName = "roleid",
    	LinkToAttributeName = "roleid",
    	JoinOperator = JoinOperator.LeftOuter,
    	Columns = new ColumnSet(true),
    	EntityAlias = "userroles",
    	LinkCriteria =
    	{
    		Conditions =
    		 {                         
    			 new ConditionExpression {
    				 AttributeName = "systemuserid",
    				 Operator = ConditionOperator.Equal,
    				 Values = { "xyz" }
    			 }
    		 }
    	}
    };
    
    QueryExpression roleQuery = new QueryExpression
    {
    	EntityName = "role",
    	ColumnSet = new ColumnSet(true),
    	Criteria =
    	{
    		Filters = {
    			new FilterExpression{
    				FilterOperator = LogicalOperator.And,
    				Conditions = {
    					new ConditionExpression{
    						EntityName = "systemuserroles",
    						AttributeName = "roleid",
    						Operator = ConditionOperator.Null
    					}
    				}
    			}                    
    		},
    		Conditions = { 
    					new ConditionExpression { 
    						AttributeName = "name", 
    						Operator = ConditionOperator.Equal, 
    						Values = { "RoleName"}
    					}
    				}
    	},
    	LinkEntities = { userRoles }
    };
