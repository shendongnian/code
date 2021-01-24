    List<DateTime> ret = new List<DateTime>();
    QueryExpression qe = new QueryExpression("calendar");
    qe.Criteria.AddCondition("name", ConditionOperator.Equal, "Business Closure Calendar");
    EntityCollection ec = service.RetrieveMultiple(qe);
    if (ec.Entities.Count != 1) { return ret; }
    Entity calendar = ec.Entities[0];
    if(!calendar.Contains("calendarrules")) { return ret; }
    EntityCollection rules = calendar.GetAttributeValue<EntityCollection>("calendarrules");
    foreach (Entity rule in rules.Entities)
    {
        ret.Add(rule.GetAttributeValue<DateTime>("startime"));
        // Console.Out.WriteLine("{0}:{1}", rule["starttime"], rule["name"]);
    }
    return ret;
