    [WebMethod]
    public static string salesInvoiceFinalCalculaiton(string InvoiceNo)
    {
            List<SalesInvoiceFinalCalculationEntity> list = new List<SalesInvoiceFinalCalculationEntity>();
            list = SalesInvoiceManager1.salesInvoiceFinalCalculaiton(InvoiceNo);
            return JsonConvert.SerializeObject(list);
    }
