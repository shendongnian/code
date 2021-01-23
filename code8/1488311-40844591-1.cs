    _invoiceRepositoryMock
        .Setup(m => m.Get(
            It.IsAny<Expression<Func<InvoiceEntity, bool>>>(),
            It.IsAny<Func<IQueryable<InvoiceEntity>, IOrderedQueryable<InvoiceEntity>>>(),
            It.IsAny<string>()))
        .Returns(...);
