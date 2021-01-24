    iTextSharp.text.Document doc = new iTextSharp.text.Document();
    
    //pdfpath is the full path of where you want the pdf to be created
    //keep in mind to check for directory existence
    PdfWriter.GetInstance(doc, new FileStream(pdfpath, FileMode.Create));
    doc.Open();
    
    //files is a list of your files as FileInfo
    foreach (var file in files)
    {
      try
      {
        Image docImage = Image.GetInstance(file.FullName);
        //scale the images to fit the document size
        docImage.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
        docImage.Alignment = Image.ALIGN_CENTER; //align the pictures
        doc.Add(docImage);
      }
      catch (Exception ex)
      {
        //exception handle logic
      }
      finally
      {
         doc.close();
      }      
    }
