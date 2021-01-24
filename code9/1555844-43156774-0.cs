    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
    Response.ContentType = "text/plain";
    Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
    Response.Write(stringToSend);
    Response.Flush();
