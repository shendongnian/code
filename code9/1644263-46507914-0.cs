        Entity ApprovalProductEnt = new Entity("new_ticketproduct");
    
        ApprovalProductEnt["new_productgroup"] = Row.ProductGroup;
        ApprovalProductEnt["new_producttype"] = Row.ProductType;
        ApprovalProductEnt["new_productitem"] = Row.ProductItem;
        Guid TicketNumberId = new Guid();
        TicketNumberId = getTicketNumber(Row.OppportunityID, ref organizationservice);
    
        //update
        if (TicketNumberId != Guid.Empty)
        {
            ApprovalProductEnt["new_ticket"] = new EntityReference("new_pricingapprovalticket", TicketNumberId);
        }
        else
        //create
        {
            Entity TicketEnt = new Entity("new_pricingapprovalticket");
            TicketEnt["new_name"] = Row.OppportunityID;
            TicketNumberId = organizationservice.Create(TicketEnt);
    
            ApprovalProductEnt["new_ticket"] = new EntityReference("new_pricingapprovalticket", TicketNumberId);
        }
       organizationservice.Create(ApprovalProductEnt);
    }
    public Guid getTicketNumber(string ticketnumber, ref IOrganizationService service)
    {
        Guid TicketNumberGuid = Guid.Empty;
        QueryExpression TicketNumberQuery = new QueryExpression { EntityName = "new_pricingapprovalticket", ColumnSet = new ColumnSet(true) };
        TicketNumberQuery.Criteria.AddCondition("new_ticketnumber", ConditionOperator.Equal, ticketnumber);
        EntityCollection TicketNumberQueryRetrieve = service.RetrieveMultiple(TicketNumberQuery);
    if (TicketNumberQueryRetrieve.Entities.Count > 0)
        TicketNumberGuid = TicketNumberQueryRetrieve.Entities[0].GetAttributeValue<Guid>("new_ticket");
    return TicketNumberGuid;
    }
