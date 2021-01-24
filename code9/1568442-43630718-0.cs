    string pdfpath = Server.MapPath("PDFs");
    string imagepath = Server.MapPath("Images");
    Document doc = new Document();
    try
    {
      PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Images.pdf", FileMode.Create));
      doc.Open();
     
      doc.Add(new Paragraph("GIF"));
      Image gif = Image.GetInstance(imagepath + "/mikesdotnetting.gif");
      doc.Add(gif);
    }
    catch (Exception ex)
    {
      //Log error;
    }
    finally
    {
      doc.Close();
    }
     
