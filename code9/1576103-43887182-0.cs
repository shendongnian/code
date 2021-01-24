    public ActionResult GetPdf(string filename)
    {
       var invoice = db.Invoices.ToList().Find(x=>x.InvoicePath==filename);
       return File("~/Invoice/" + invoice.InvoicePath, "application/pdf", Server.UrlEncode(invoice.InvoicePath));
    }
