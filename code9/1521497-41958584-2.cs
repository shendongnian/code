    public ViewResult Display()
    {
        var posts = db.Posts.Select(d => new PostVM()
        {
            ID = d.ID ,
            Heading  = d.Heading,
            Body = d.Body,
            Images = d.Images.Select(i => new ImageVM() { Path = i.Path, 
                                                          DisplayName = i.DisplayName }
                                    ).ToList()
        }).ToList();
        return View(posts);
    }
