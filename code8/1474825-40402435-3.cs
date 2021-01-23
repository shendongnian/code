    public override void InitializeDatabase(InvoiceContext context)
    {
         // if not exists, create the stored procedure
         context.CreateProcedureProcessUsageCosts(false);
    }
