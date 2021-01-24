    [AcceptVerbs("POST")]
    public int Add(string post,string title, string user)
    {
        if (post == null)
            throw new Exception("Post content not added");
        if (title == null)
            throw new Exception("Post title not added");
        var u = UserManager.FindByEmailAsync(user);
        Blog blog = Blog.Create(u.Result.Account.RowKey, post, title).Save();
        return blog.Id;
    }
