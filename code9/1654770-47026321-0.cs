    objQueryExpression1.LinkEntities.Add(new LinkEntity("activitypointer", "email", "activityid", "activityid", JoinOperator.LeftOuter));
    
    objQueryExpression1.LinkEntities[0].EntityAlias = "filteredemails";
    objQueryExpression1.LinkEntities[0].LinkCriteria.AddCondition("csiro_confidential", ConditionOperator.NotEqual, true);
    objQueryExpression1.LinkEntities.Add(new LinkEntity("activitypointer", "task", "activityid", "activityid", JoinOperator.LeftOuter));
    
    objQueryExpression1.LinkEntities[1].EntityAlias = "filteredTasks";
    objQueryExpression1.LinkEntities[1].LinkCriteria.AddCondition("csiro_newfield", ConditionOperator.Equal, true);
