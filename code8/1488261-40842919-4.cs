    public ActionResult Feed()
    {
        List<Models.Post> posts = getPosts();
        return PartialView(posts);
    }
