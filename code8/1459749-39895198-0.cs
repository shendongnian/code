    protected void Page_Load(object sender, EventArgs e)
    {
        // code to set up DB connections
        ExternalLibrary.SetupDB(); 
    }
    [WebMethod]
    public static string AjaxAccessibleMethod()
    {
        ExternalLibrary.SetupDB();
        ...
    }
