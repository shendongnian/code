    QueryExpression query = new QueryExpression(new_supplycontract.EntityLogicalName);
    query.ColumnSet = new ColumnSet(true);
    var le = query.LinkEntities.Add(new LinkEntity(new_pod.EntityLogicalName, "new_pod", "new_pod", "new_podid", JoinOperator.Inner)); 
    var lePod = le.LinkEntities.Add(new LinkEntity(new_pod.EntityLogicalName, "new_city", "new_citypod", "new_cityid", JoinOperator.Inner));
    var leCity = le.LinkEntities.Add(new LinkEntity(new_pod.EntityLogicalName, "new_street", "new_street", "new_streetid", JoinOperator.Inner));
    //Add conditions to each nested linked entity now as above.
