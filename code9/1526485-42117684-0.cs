    private static PermanentPlacement PopulatePermanentPlacement(InvoiceLine invoiceLine)
    {
        var creditReissue = invoiceLine.CreditReissue;
        while(creditReissue.InvoiceLine.PermanentPlacement == null)
            creditReissue = creditReissue.InvoiceLine.CreditReissue;
        return creditReissue.InvoiceLine.PermanentPlacement;
    }
