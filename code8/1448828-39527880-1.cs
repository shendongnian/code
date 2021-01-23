    [... create StringReader sr ...]
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=InvoiceSJ.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);                        
    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    pdfDoc.Open();
    htmlparser.Parse(sr);
    pdfDoc.Close();
    Response.End();
