    using (var dbContext - new InvoiceContext(...))
    {
        UsageCosts params = new UsageCosts()
        {
            ...
        };
        dbContext.CallStoredProcedureUsageCost(params);
    }
