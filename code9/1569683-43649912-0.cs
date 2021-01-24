    public abstract class InvoiceDetailBase<T> where T : Invoice
    {
        public virtual ICollection<T> Invoices { get; set; }
    }
    public class InvoiceDetail : InvoiceDetailBase<Invoice>
    {
    }
    public class SalesInvoiceDetail : InvoiceDetailBase<SalesInvoice>
    {
    }
