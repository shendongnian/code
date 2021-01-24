    public IActionResult Add(NewPostModel model)
    {
        return new Post()
        {
            Title = model.Title,
    
            PostTags = new List ()
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
