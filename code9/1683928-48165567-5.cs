    [System.Web.Services.WebMethod]
    public static void MyMethod(string data)
    {
        string[] arrValue = data.Split('§');
        ...
    }
