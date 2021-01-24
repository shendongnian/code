    private static PermanentPlacement PopulatePermanentPlacementRec(InvoiceLine invoiceLine)
    {
      return 
        invoiceLine.PermanentPlacement ?? 
        PopulatePermanentPlacementRec(invoiceLine.CreditReissue.InvoiceLine);
    } 
    private static PermanentPlacement PopulatePermanentPlacement(InvoiceLine invoiceLine)
    {
      return PopulatePermanentPlacementRec(invoiceLine.CreditReissue.InvoiceLine);
    }
