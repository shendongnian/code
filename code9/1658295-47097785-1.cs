    public IActionResult Add(NewPostModel model)
    {
        return new Post()
        {
            Title = model.Title,
    
            PostTags = new List<PostTag> ()
            {
                new PostTag ()
                {
                    Tag = new Tag ()
                },
                new PostTag ()
                {
                    Tag = new Tag()
                }    
            }
        }
    }
