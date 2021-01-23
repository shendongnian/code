    PdfDocument doc = converter.ConvertHtmlString("www.cnn.com");
    byte[] bytes = doc.Save();
    string mimeType = "Application/pdf";
    Response.Buffer = true;
    Response.Clear();
    Response.ContentType = mimeType;
    Response.OutputStream.Write(bytes, 0, bytes.Length);
    Response.Flush(); 
    Response.End();
