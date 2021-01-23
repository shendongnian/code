    public class Product : RealmObject
    {
        /* other properties */
        [Backlink(nameof(Invoice.Products))]
        public IQueryable<Invoice> RelatedInvoices { get; }
    }
