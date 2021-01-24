    public IHttpActionResult Get()
    {
        /// get JSON
        return base.Json(jsonResult.ToString());
    }
