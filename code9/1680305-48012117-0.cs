            LinkEntity Link2 = new LinkEntity("entity2", "entity3", "entity3Id", "entity3Id", JoinOperator.LeftOuter);
            Link2.LinkCriteria.AddCondition(new ConditionExpression("statecode", ConditionOperator.Equal, 0));         
            Link2.Columns = new ColumnSet("entity3Data");
            Link2.EntityAlias = "entity3";
            query.LinkEntities.Add(Link2);
