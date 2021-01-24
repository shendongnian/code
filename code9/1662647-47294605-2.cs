    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetObject()
    {
        string json = GetJsonFromDatabase();
        HttpContext.Current.Response.Write(json);
    }
