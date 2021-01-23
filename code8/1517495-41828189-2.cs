    [System.Web.Services.WebMethod]
    public static string lookupfromjs_Click(String query)
    {
        return "query was " + HttpUtility.UrlEncode(query);
    }
