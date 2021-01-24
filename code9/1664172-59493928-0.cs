    public void ProcessRequest(object Request)
    {
        Type oT = Request.GetType();
        string URL = oT.GetProperty("RawUrl").GetValue(Request).ToString();
        // do something
    }
