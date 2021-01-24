    public static string GetContextTokenFromRequest(HttpRequestBase request)
    {
        string[] paramNames = { "AppContext", "AppContextToken", "AccessToken", "SPAppToken" };
        foreach (string paramName in paramNames)
        {
            if (!string.IsNullOrEmpty(request.Form[paramName]))
            {
                return request.Form[paramName];
            }
            if (!string.IsNullOrEmpty(request.QueryString[paramName]))
            {
                return request.QueryString[paramName];
            }
        }
        if (request.Cookies["AppContextToken"] != null)
        {
            return request.Cookies["AppContextToken"].Value;
        }
        return null;
    }
