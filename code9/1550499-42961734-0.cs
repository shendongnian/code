    [Route("api/Getsmth/{a}/{b}/{c}")]
    public async Task<IHttpActionResult> Get(string a, string b, string c)
    {
       HttpClient client = new HttpClient();
       var r = await Getsmth(a, b, c, client);
       return Ok(r);
     }
