    Response.Buffer = true;
    Response.Clear();
    Response.ContentType = mimeType;
    Response.AddHeader("content-disposition", "attachment; filename= filename" + "." + extension);
    Response.OutputStream.Write(bytes, 0, bytes.Length);
    Response.Flush();
    Response.End();
