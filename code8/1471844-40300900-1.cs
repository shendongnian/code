    ActionResult MyAction(int? id = null)
    {
        // ...
        IQueryable<QuoteDocuments> docs = dbContext.tblSalesQuoteDocuments;
        if (id != null)
        {
            docs = docs.Where(x => x.HeaderId == id.Value);
        }
        var list = docs.ToList();
        // ...
    }
