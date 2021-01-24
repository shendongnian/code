    var size= PageSize.A4;
    NewExportToPDFforLetter(stringWriter, "Application Approval Letter", HttpContext.Current.Response,(Rectangle)size);
    public void NewExportToPDFforLetter(StringWriter sw, string FileName, HttpResponse Response, Rectangle s )
    {
        Document pdfDoc = new Document(s, 30f, 30f, 30f, 30f);
    }
