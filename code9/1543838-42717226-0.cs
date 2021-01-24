    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
    Attachment attach = new Attachment(ms, ct);
    
    //And in your mail message
    mail.Attachments.Add(attach);
    
    //And remember to clean up
    writer.Flush();
    writer.Dispose();
    ms.Dispose();
