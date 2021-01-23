    [WebMethod]
    public static void LoadImages()
    {
        Label1.Text = "hi therre";
        Response.Redirect("www.google.com");
        log.Debug("LoadImages is called");
    }
