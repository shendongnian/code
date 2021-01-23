    [HttpPost]
    [Route("send")]
    [Authorize(Roles = "Admin")]
    public IHttpActionResult Send(int[] ids)
    {
        foreach (var id in ids)
        {
    
        }
    }
