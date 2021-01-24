    private static PermanentPlacement PopulatePermanentPlacement(InvoiceLine invoiceLine)
    {
        var creditReissue = invoiceLine.CreditReissue;
    	while (creditReissue.InvoiceLine.CreditReissue != null)
    	{
            // Get the last credit reissue
    		creditReissue = creditReissue.InvoiceLine.CreditReissue;
    	}
    	return creditReissue.InvoiceLine.PermanentPlacement;    
    }
