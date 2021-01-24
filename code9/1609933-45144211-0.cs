    //Create a query expression specifying the link entity alias 
    //and the columns of the link entity that you want to return
    QueryExpression qe = new QueryExpression();
    qe.EntityName = "appointment";
    qe.ColumnSet = new ColumnSet(true);
    //LinkEntity for ActivityParty                
    var activityParty = new LinkEntity()
    {
        EntityAlias = "activityparty",
        JoinOperator = JoinOperator.Inner,
        Columns = new ColumnSet(true),
        LinkFromEntityName = "appointment",
        LinkFromAttributeName = "activityid",
        LinkToEntityName = "activityparty",
        LinkToAttributeName = "activityid",
        LinkCriteria = new FilterExpression
        {
            Conditions =
                       {
                           new ConditionExpression("participationtypemask", ConditionOperator.Equal, 5), //Required Attendees 
                           new ConditionExpression("partyobjecttypecode", ConditionOperator.Equal, 2),   // Contacts
                       }
        }
    };
    //LinkEntity for Contact                
    var contact = new LinkEntity()
    {
        EntityAlias = "contact",
        JoinOperator = JoinOperator.Inner,
        Columns = new ColumnSet(true),
        LinkFromEntityName = "activityparty",
        LinkFromAttributeName = "partyid",
        LinkToEntityName = "contact",
        LinkToAttributeName = "contactid",
    };
    activityParty.LinkEntities.Add(contact);
    qe.LinkEntities.Add(activityParty);
    //Get the appointments and the Linked Entities
    var appointments = _orgService.RetrieveMultiple(qe);
    foreach (var appointment in appointments.Entities)
    {
        // Do something with the Contact Data 
        var fullname = ((AliasedValue)(appointment["contact.fullname"])).Value.ToString();
    }
