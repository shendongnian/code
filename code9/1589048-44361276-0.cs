    //PostController.cs
    [HttpPut]
    [Route("api/posts/{id}/save")] // Matches PUT api/posts/2/save
    public IHttpActionResult Save(int id, [FromBody]Post post) {
        PostsStore store = new PostsStore();
        ResponseResult AsyncResponse = store.Save(post);
        return Ok(AsyncResponse);    
    }
