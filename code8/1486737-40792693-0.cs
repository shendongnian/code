    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment; filename=" + fileName.Replace(",",&#44;");
    Response.CacheControl = "No-cache";
    Response.Write(data);
    Response.Flush();
    Response.SuppressContent = true;
    HttpContext.Current.ApplicationInstance.CompleteRequest();
