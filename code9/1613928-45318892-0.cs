    public ActionResult ConverToPdf(string htmlContent)
            {
                try
                {
    
                    // instantiate a html to pdf converter object
                    HtmlToPdf converter = new HtmlToPdf();
                    PdfPageSize pageSize = PdfPageSize.A4;
                    PdfPageOrientation pdfOrientation = PdfPageOrientation.Portrait;
                    int webPageWidth = 1024;
                    // set converter options
                    converter.Options.PdfPageSize = pageSize;
                    converter.Options.PdfPageOrientation = pdfOrientation;
                    converter.Options.WebPageWidth = webPageWidth;
                    converter.Options.MarginLeft = 10;
                    converter.Options.MarginRight = 10;
                    converter.Options.MarginTop = 5;
                    converter.Options.MarginBottom = 5;
                    //converter.Options.WebPageHeight = webPageHeight;
    
                    // create a new pdf document converting an url
                    PdfDocument doc = converter.ConvertHtmlString(htmlContent);
    
                    // save pdf document
                    byte[] pdf = doc.Save();
    
                    // close pdf document
                    doc.Close();
    
                    // return resulted pdf document
                    FileResult fileResult = new FileContentResult(pdf, "application/pdf");
                    fileResult.FileDownloadName = "Document.pdf";
                    return fileResult;
    }
