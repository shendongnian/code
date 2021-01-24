    try
    {
        Entity email = (Entity)context.InputParameters["Target"];
    
        //  Post Entity Image (since the plug-in is registered on "Update")
        Entity postImage = context.PostEntityImages["Image"];
    
        EntityCollection fromCollection = postImage.GetAttributeValue<EntityCollection>("from");
    
        if (fromCollection != null && fromCollection.Entities.Count > 0)
        {
            Entity sender = fromCollection[0];
            EntityReference partyId = sender.GetAttributeValue<EntityReference>("partyid");
    
            string entityType = partyId.LogicalName.ToString();
    
            if (entityType == "systemuser")
                {
                    //  Create query using querybyattribute
                    QueryByAttribute queryToSender = new QueryByAttribute("systemuser");
                    queryToSender.ColumnSet = new ColumnSet("systemuserid", "internalemailaddress");
    
                    //  Attribute to query
                    queryToSender.Attributes.AddRange("systemuserid");
    
                    //  Value of queried attribute to return
                    queryToSender.Values.AddRange(partyId.Id);
    
                    EntityCollection retrievedFromSystemuser = service.RetrieveMultiple(queryToSender);
    
                    foreach (Entity systemuserE in retrievedFromSystemuser.Entities)
                        {
                            email["new_samplefield"] = (string)systemuserE.Attributes["internalemailaddress"];                          
                        }
                }                     
            }
                        
        service.Update(email);
    }
