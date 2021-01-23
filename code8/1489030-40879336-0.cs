    var qe = QueryExpressionFactory.Create<new_supplycontract>();
    var podLink = qe.AddLink<new_pod>(new_supplycontract.Fields.new_Pod, new_pod.Fields.Id);
    
    podLink.AddLink<new_city>(new_pod.Fields.new_citypod, 
                              new_city.Fields.Id, 
                              new ColumnSet(new_city.Fields.new_name))
        .LinkCriteria.AddCondition("new_name", ConditionOperator.Like, "%" + comune + "%");
    podLink.AddLink<new_street>(new_pod.Fields.new_street, 
                                new_street.Fields.Id,
                                ColumnSet(new_street.Fields.new_name))
        .LinkCriteria.AddCondition("new_name", ConditionOperator.Like,  "%" + via + "%");
    var leads = service.GetEntities(qe);
