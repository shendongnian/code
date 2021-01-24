    private static InvoiceDTO ToInvoiceDTO(Invoice invoice)
    {
        InvoiceDTO e = new InvoiceDTO()
        {
            InvoiceID = invoice.InvoiceID,
            InvoiceTotal = invoice.TotalAmount
        };
    
        e.ServiceChargeLineItems = invoice.InvoiceServiceXrefs.
                                   Select(b => new ServiceChargeDTO
                                   {
                                       ServiceChargeID = b.ServiceChargeID,
                                       Quantity = b.ServiceCharge.Qty,
                                       UnitPrice = b.ServiceCharge.UnitPrice,
                                       Amount = b.ServiceCharge.Amount
                                   }).ToList()
    
        return e;
    }
