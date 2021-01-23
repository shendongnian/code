    [WebMethod]
    public static string GetData (string MarketName, string Category, string Symbol)
    {
        MyClassName.MarketName = MarketName.ToLower(); 
        // ...
    }
