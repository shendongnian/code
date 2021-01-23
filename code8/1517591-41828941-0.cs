    public class Invoice
    {
        // ...
        public ICollection<InvoiceDetail> Details { get; set; }
    }
    
    public class InvoiceDetail
    {
        // ...
        public ICollection<Mixing> Mixings { get; set; }
    }
