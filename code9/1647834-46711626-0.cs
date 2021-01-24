    QueryExpression query = new QueryExpression("annotation")
        {
            Criteria = new Microsoft.Xrm.Sdk.Query.FilterExpression()
            {
                Conditions =
                {
                    new ConditionExpression("objectid",ConditionOperator.Equal,incidentGuid)
                }
            },
            ColumnSet = new ColumnSet(true)
        };
