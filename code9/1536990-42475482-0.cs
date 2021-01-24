    public ActionResult File()
    {
      string ingredientNames = "Hello David";
      using (MemoryStream stream = new MemoryStream())
      {
        var doc = new Document();
        PdfWriter.GetInstance(doc, stream).CloseStream = false;
    
        doc.Open();
        doc.Add(new Paragraph(ingredientNames.ToString()));
        doc.Close();
    
        return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "file.pdf");
      }
    }
