    [System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string CreateForm(object data)
    {
        Repository repo = new Repository();
        repo.Insert(data);
    }
