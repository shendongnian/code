         invoiceLines.OrderBy(Func1)
         //.ThenBy(Func2).
         //ThenBy(Func3).
         ToList();
    
    private static string Func1(InvoiceLine invoiceLine) =>
    			invoiceLine.TransactionLines.OfType<PermanentPlacementTransactionLine >().First()
    				.OrderReference ;
