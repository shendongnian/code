    [HttpPost]
    [Route("rename/{userId}", Name = "RenameUserPost")]
    public IHttpActionResult RenameUserPost(int userId, [FromBody] User userData)
    {
        return new StatusCodeResult(HttpStatusCode.Created, this);
    }
