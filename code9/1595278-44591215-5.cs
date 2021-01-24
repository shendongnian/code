    public class test
    {
        [JsonConverter(typeof(InvoiceDetailConverter<InvoiceDetail, IInvoiceDetail>))]
        public List<IInvoiceDetail> InvoiceDetail { get; set; }
        [JsonConverter(typeof(InvoiceDetailConverter<VatDetail, IVatDetail>))]
        public List<IVatDetail> VatDetail { get; set; }
    }
