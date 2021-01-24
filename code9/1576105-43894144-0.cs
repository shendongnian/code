     public ActionResult GetPdf(int id)
            {
                var invoice = db.Invoices.Find(id);
    
                return File("~/Invoice/" + invoice.InvoicePath, "application/pdf", Server.UrlEncode(invoice.InvoicePath));
            }
