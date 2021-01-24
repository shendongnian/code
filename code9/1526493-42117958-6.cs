    private static PermanentPlacement PopulatePermanentPlacement(
      InvoiceLine invoiceLine)
    {
      return CreditReissues(invoiceLine.CreditReissue)
        .Select(cr => cr.InvoiceLine.PermanentPlacement)
        .First(pp => pp != null);
    }
