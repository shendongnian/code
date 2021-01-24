    [System.Web.Http.HttpGet]
    public IHttpActionResult Index()
    {
        var info = new ApplicationInformation
        {
            ApplicationName = "Test App",
            DatabaseName = "SQL Server 2012",
            ApplicationVersion = "3.10.0"
        };
        return Json(info);
    }
