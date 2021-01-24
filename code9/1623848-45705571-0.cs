    [HttpPost]
    public HttpResponseMessage PostSendPdf(Information info)
    {
        // Your email sending mechanism, Use info object where you need, for example, info.Email
        var coverHtml = RenderRazorViewToString("~/Views/Home/Test.cshtml", null);
        var htmlContent = RenderRazorViewToString( "~/Views/Home/Test2.cshtml", null);
        string path = HttpContext.Server.MapPath("~/Content/PDF/html-string.pdf");
        PDFGenerator.CreatePdf(coverHtml, htmlContent, path);
        //PDFGenerator.CreatePdfFromURL("https://www.google.com", path);
        EmailHelper.SendMail(info.Email, "Test", "HAHA", path);
        
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
        return response;
    }
