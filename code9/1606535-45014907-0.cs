    public ActionResult PrintInvoice(string invoiceNumber)
    {
        string fileloc = GetInvoiceFileLocation(invoiceNumber);
        fileBytes = System.IO.File.ReadAllBytes(fileloc);
        ms = new MemoryStream();
        ms.Write(fileBytes, 0, fileBytes.Length);
    
        ms.Position = 0;    
    
        return File(ms, "application/pdf");
    }
