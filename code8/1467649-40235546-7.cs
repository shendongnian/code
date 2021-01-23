    // This one gets called from Application_Error
    // You can add additional parameters to this action if needed
    public ActionResult Index(Exception exception)
    {
       ...
    }
    
    // This one gets called by IIS (see Web.config)
    public ActionResult Display([Bind(Prefix = "id")] HttpStatusCode statusCode)
    {
        ...
    }
