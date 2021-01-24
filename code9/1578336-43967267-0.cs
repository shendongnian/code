    static List<Entity> GetAllAccounts(IOrganizationService service)
    {
        var query = new QueryExpression { EntityName = "account", ColumnSet = new ColumnSet(false) };
        var accounts = service.RetrieveMultiple(query).Entities.ToList();
       return accounts;
    }
    
