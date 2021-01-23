    [WebMethod]
    public static void MyMethod()
    {
    .....
    ...
    ..
    string result = JsonConvert.SerializeObject(_d);
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ContentType = "application/json";
    HttpContext.Current.Response.AddHeader("content-length", result.Length.ToString());                HttpContext.Current.Response.Flush();
    HttpContext.Current.Response.Write(result);
    HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
