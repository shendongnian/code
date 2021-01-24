    QueryExpression sysUsersQuery = new QueryExpression()
    {
        EntityName = "systemuser",
        ColumnSet = new ColumnSet("systemuserid"),
        LinkEntities = {
            new LinkEntity
            {
                LinkFromEntityName = "systemuser",
                LinkToEntityName = "new_salesorder_systemuser",
                LinkFromAttributeName = "systemuserid",
                LinkToAttributeName = "systemuserid",
                JoinOperator = JoinOperator.Inner,
                LinkEntities =
                {
                    new LinkEntity()
                    {
                        EntityAlias = "ab",
                        LinkFromEntityName = "systemuser",
                        LinkToEntityName = "salesorder",
                        LinkFromAttributeName = "salesorderid",
                        LinkToAttributeName = "salesorderid",
                        JoinOperator = JoinOperator.Inner,
                        LinkCriteria = new FilterExpression()
                        {
                            Conditions = {
                                new ConditionExpression("salesorderid",ConditionOperator.Equal, "sfsdf")
                            }
                        }
                    }
                }
            }
        }
    };
