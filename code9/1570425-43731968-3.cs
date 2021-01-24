    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    Response.ContentType = "application/pdf";
    Response.ContentEncoding = System.Text.Encoding.UTF8;
    Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
    Response.BinaryWrite(pdfBytes);
    Response.Flush();
    Response.Close()
    Response.End()
