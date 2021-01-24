    [Fact]
    public async Task Test_InsertAndQuery()
    {
        var invoiceRepository = Resolve<IRepository<InvoiceHistory, long>>();
        var unitOfWorkManager = Resolve<IUnitOfWorkManager>();
        
        using (var uow = unitOfWorkManager.Begin())
        {
            var invoice = new InvoiceHistory() { Reference = "1", Payments = new List<Payment> { new Payment() } };
            var ihId = await invoiceRepository.InsertAndGetIdAsync(invoice);
            var readInvoice = await invoiceRepository
                .Query(q => q.Where(ih => ih.Id == ihId))
                .Include(ih => ih.Payments)
                .FirstOrDefaultAsync();
            // ...
            await uow.CompleteAsync();
        }
    }
