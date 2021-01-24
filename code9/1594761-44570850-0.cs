    class Invoices
    {
        public Invoices(DbContext dbContext){....}
        public Invoice GetInvoiceById(int invoiceId)
        {
            return this.dbContext.Invoices
                .ForId(invoiceId)
                .Include(i => i.Payments)
                .Include(i => i.OrderLines)
                .FirstOrDefault();
        }
    ...
