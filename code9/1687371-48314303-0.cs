    [WebMethod]
    public static string GetCustomers()
    {
        string strId = HttpContext.Current.Request.QueryString["Id"];
        //dosomething    
    }
