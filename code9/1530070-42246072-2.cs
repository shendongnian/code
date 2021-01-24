    public class InvoicePair
    {
        public InvoicePair(EInvoice eInvoice, TradeInvoice tradeInvoice)
        {
            TradeInvoice = tradeInvoice;
            EInvoiceInfo = eInvoice;
        }
        public EInvoice EInvoiceInfo { get; set; }
        public TradeInvoice TradeInvoice { get; set; }
    }
