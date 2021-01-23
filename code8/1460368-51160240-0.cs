    // do actual initialization - but that's another topic :)
    IOrganizationService organizationService = null;
    var query = new QueryExpression
    {
      NoLock = true,
      TopCount = 1,
      EntityName = "account",
      // if you want to check just for existence of record use ColumnSet(false)
      // if you want to check entity columns use ColumnSet(true) 
      // or specify columns you want to fetch
      ColumnSet = new ColumnSet(false)
    };
    
    query.Criteria.AddCondition(
      "accountid", 
      ConditionOperator.Equal, 
      new Guid("36345eb0-728c-e611-9421-00153d29152e"));
    var entities = organizationService.RetrieveMultiple(query);
    // entities.Entities is guaranteed to be not null
    if (entities.Entities.Count == 0)
    {
      // snap - no such entity
      return;
    }
    
    var entity = entities.Entities[0];
