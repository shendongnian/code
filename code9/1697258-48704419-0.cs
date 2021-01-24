    [HttpPost]
    [NhSessionManagement()]
    [ODataRoute("BatchUpdate")]
    public async Task<IHttpActionResult> BatchUpdate(Item[] items, bool updateDefaultJSONFile)
    {
        return Ok();
    }
