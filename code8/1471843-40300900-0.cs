    IQueryable<QuoteDocuments> docs = dbContext.tblSalesQuoteDocuments;
    if (id >= 0)
    {
        docs = docs.Where(x => x.HeaderId == id);
    }
    var list = docs.ToList();
