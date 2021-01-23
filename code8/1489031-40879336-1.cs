    var qe = QueryExpressionFactory.Create<new_supplycontract>();
    var podLink = qe.AddLink<new_pod>(new_supplycontract.Fields.new_Pod, new_pod.Fields.Id);
    
    podLink.AddLink<new_city>(new_pod.Fields.new_citypod,              // This is the attribute of the "from" entity to join on
                              new_city.Fields.Id,                      // This is the attribute of the "to" entity to join on.  If name is identical, this parameter can be removed
                              new ColumnSet(new_city.Fields.new_name)) // AliasedValue to add to the result
        .LinkCriteria.AddCondition("new_name", ConditionOperator.Like, "%" + comune + "%");
    podLink.AddLink<new_street>(new_pod.Fields.new_street, 
                                new_street.Fields.Id,
                                ColumnSet(new_street.Fields.new_name))
        .LinkCriteria.AddCondition("new_name", ConditionOperator.Like,  "%" + via + "%");
    var leads = service.GetEntities(qe);
