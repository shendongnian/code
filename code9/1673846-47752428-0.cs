    public static Task<Dictionary<string, string>> GetExampleDictAsync(string id)
    {
        string url = baseUrl + "GetExampleDictionary/" + id;
        return WebReq<Dictionary<string, string>>(url, "POST");
    }
