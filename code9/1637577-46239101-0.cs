    [WebMethod]
    public ActionResult List<SalesInvoiceFinalCalculationEntity> salesInvoiceFinalCalculaiton(string InvoiceNo)
    {
            List<SalesInvoiceFinalCalculationEntity> list = new List<SalesInvoiceFinalCalculationEntity>();
            list = SalesInvoiceManager1.salesInvoiceFinalCalculaiton(InvoiceNo);
            return Json(list);
    }
