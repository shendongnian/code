    public Invoice() 
    {
        InvoiceProducts = new List<InvoiceProcuct>();
    }
    public ICollection<InvoiceProduct> InvoiceProducts { get; }
