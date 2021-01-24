    string pdfPath = Server.MapPath("~/SomePDFFile.pdf");
    WebClient client = new WebClient();
    Byte[] buffer = client.DownloadData(pdfPath);
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-length", buffer.Length.ToString());
    Response.BinaryWrite(buffer);
