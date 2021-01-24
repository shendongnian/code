     //you can use FileResult, same outcome
        public ActionResult ABC()
                {
                    var htmlContent = System.IO.File.ReadAllText(Server.MapPath("~/Views/abc/abc.html"));
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
                    //return File(pdfBytes, "application/pdf", "TEST.pdf"); 
                    //will add filename to your response, downside is that browser downloads the response
                    //if your really need Content Disposition in response headers uncomment below line
                    //Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
                    return File(pdfBytes, "application/pdf");
                    
                }
