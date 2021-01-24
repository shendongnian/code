    String FileName = "FileName.txt";
    String FilePath = "C:/...."; //Replace this
    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.ClearContent();
    response.Clear();
    response.ContentType = "text/plain";
    response.AddHeader("Content-Disposition", "attachment; filename=" + FileName 
    + ";");
    response.TransmitFile(FilePath);
    response.Flush();
    response.End();
