    public ActionResult Create(int? id, string title, string body, DateTime datetime, string tags)
    {
        Post post = GetPost(id);
        post.Title = title;
        post.Body = body;
        post.Tags.Clear();
        Tags tagsList = new Tags(tags, this._context.Tags);
        post.Tags = tagsList.ToList();
    }
