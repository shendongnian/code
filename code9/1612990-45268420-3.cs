    public class InvoiceAsSalesTransactionRepository : IRepostory<SalesTransaction>
    {
        private readonly IRepostory<Invoice> _invoiceRepository = new InvoiceRepository();
        public void Add(SalesTransaction item)
        {
            if (item is Invoice invoice) {
                _invoiceRepository.Add(invoice);
            } else {
                throw new ArgumentException("Item must be Invoice");
            }
        }
        public SalesTransaction First(Expression<Func<SalesTransaction, bool>> predicate)
        {
            return _invoiceRepository.First(ToInvoicePredicate(predicate));
        }
        public SalesTransaction Single(Expression<Func<SalesTransaction, bool>> predicate,
                                       bool disableTracking = false)
        {
            return _invoiceRepository.Single(ToInvoicePredicate(predicate), disableTracking);
        }
        private static Expression<Func<Invoice, bool>> ToInvoicePredicate(
            Expression<Func<SalesTransaction, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Invoice), predicate.Parameters[0].Name);
            return Expression.Lambda<Func<Invoice, bool>>(predicate.Body, param);
        }
    }
