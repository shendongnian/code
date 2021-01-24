    private static PermanentPlacement PopulatePermanentPlacement(
      InvoiceLine invoiceLine)
    {
      return invoiceLine.PermanentPlacement ??
             PopulatePermanentPlacement(
               invoiceLine.CreditReissue.InvoiceLine);
    } 
