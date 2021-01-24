    public ActionResult GetPdf(string filename)
    {
       var invoice = db.Invoices.FirstOrDefault(x=> x.InvoicePath == filename);
       return File("~/Invoice/" + invoice.InvoicePath, "application/pdf", Server.UrlEncode(invoice.InvoicePath));
    }
