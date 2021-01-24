    protected void Print_Button_Click(object sender, EventArgs e)
    {
    // create the HTML to PDF converter
    HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
    // select the HTML element to be converted to PDF
    htmlToPdfConverter.ConvertedHtmlElementSelector = "#page"                               
    // convert URL to a PDF memory buffer
    string url = "http://www.bbc.com/";
    byte[] pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);
    // inform the browser about the binary data format
    HttpContext.Current.Response.AddHeader("Content-Type",application/pdf");
    // let the browser know how to open the PDF document
    HttpContext.Current.Response.AddHeader("Content-Disposition",
                String.Format("attachment; filename=ConvertHtmlPart.pdf;
                        size ={ 0}
    ",
        pdfBuffer.Length.ToString()));
    // write the PDF buffer to HTTP response
    HttpContext.Current.Response.BinaryWrite(pdfBuffer);
    // call End() method of HTTP response 
    // to stop ASP.NET page processing
     HttpContext.Current.Response.End();
    }
