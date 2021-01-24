    [HttpPost]
    [Route("api/test")]
    public IHttpActionResult Test(JObject item)
    {
        //Check if start is included
        var data = item.ToObject<YourClass>();
        ...
       
    }
