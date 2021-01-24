    public ActionResult Download()
    {
      // Starting with pdfBytes here...
      // ...
      var pdfBytes = htmlToPdf.GeneratePdf("<html><body>" + node.InnerHtml + "</body></html>");
      var contentDisposition = new System.Net.Mime.ContentDisposition
      {
          FileName = "TEST.pdf",
          Inline = false
      };
      Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
      return File(pdfBytes, "application/pdf");
    }
