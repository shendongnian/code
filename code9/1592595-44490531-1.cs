    public async Task<IHttpActionResult> Get() {
        var store = new PostsStore();
        var posts = await store.GetPostsAsync();
        return Ok(posts);
    }
