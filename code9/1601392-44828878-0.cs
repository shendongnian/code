    [WebMethod]
    public static string GetProducts()
    {
        BigCommerceAPI api = getAPI();
        return api.getProducts().Result;
    }
