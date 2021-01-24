    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    {
      Page.RenderControl(hw);
      StringReader sr = new StringReader(sw.ToString());
      Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
      PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~") + pdfName + ".pdf");
    } 
