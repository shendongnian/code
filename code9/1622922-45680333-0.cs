        LinkEntity le = opportunityProductsQuery.AddLink(PCSEPortal.oph_submissionchannel.EntityLogicalName, “oph_submissionchannelid”, “2ndentityname2”);
        le.Columns = new ColumnSet(“oph_submissionchannelid”);
        le.LinkCriteria.AddCondition(“oph_submissionchannelid”, ConditionOperator.Equal, Guid);   //where condition
        opportunityProductsQuery.AddOrder(“modifiedon”, OrderType.Descending);
        opportunityProductsQuery.PageInfo = new PagingInfo();
        opportunityProductsQuery.PageInfo.Count = 1;
        opportunityProductsQuery.PageInfo.PageNumber = 1;
        
        EntityCollection entitycolls = service.RetrieveMultiple(equery);
