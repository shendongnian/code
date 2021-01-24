    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("api/v1/Trades")]
    public IHttpActionResult GetTrades(int page = -1, int pageSize = -1, int skip = -1, int take = -1, string sort = "")
    {
        // Do stuff ...
    }
