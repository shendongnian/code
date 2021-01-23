    var query = new QueryExpression
    {
        EntityName = "customeraddress",
        ColumnSet = new ColumnSet("customeraddressid"),
        TopCount = 1,
        Criteria = new FilterExpression
        {
            Conditions =
            {
                // limit to Address 1
                new ConditionExpression("addressnumber", ConditionOperator.Equal, 1),
                // filter by "anonymous" GUID
                new ConditionExpression("parentid", ConditionOperator.Equal, myEntityGuid),
            },
        },
        LinkEntities =
        {
            new LinkEntity
            {
                EntityAlias = "acc",
                Columns = new ColumnSet("name"),
                LinkFromEntityName = "customeraddress",
                LinkFromAttributeName = "parentid",
                LinkToAttributeName = "accountid",
                LinkToEntityName = "account",
                JoinOperator = JoinOperator.LeftOuter
            },
            new LinkEntity
            {
                EntityAlias = "con",
                Columns = new ColumnSet("fullname"),
                LinkFromEntityName = "customeraddress",
                LinkFromAttributeName = "parentid",
                LinkToAttributeName = "contactid",
                LinkToEntityName = "contact",
                JoinOperator = JoinOperator.LeftOuter
            },
        },
    };
