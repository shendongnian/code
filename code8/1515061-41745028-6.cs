    [HttpPost]
    [ODataRoute("MyAction")]
    public async Task<IHttpActionResult> MyAction(ODataActionParameters parameters)
    {
        OperationStatus status;
        if (!parameters.TryGetValue("Status",out status))
        {
            return BadRequest("Missing parameter Status");
        }
    }
