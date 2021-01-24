    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(ValueObject[] name)
    {
        string str = "";
        foreach (var s in name)
        {
            str += s.Value;
        }
        return str;
    }
