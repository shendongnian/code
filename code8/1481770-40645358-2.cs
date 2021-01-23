    var likes = (from n in _db.PostLikes where ....).ToList().Select(x => new ResponseVM()
    {
        Name = x.Name,
        Photo = Url.Content(String.Format("~/Images/{0}", x.Photo)),
        Message = String.Format(" liked your post {0}", x.PostText), // see notes below
        Image = Url.Content("~/Images/like-128.png"),
        Time = x.Time
    });
    var comments = (from n in _db.PostComments where ...).ToList().Select(x => new ResponseVM()
    {
        .... // as above except adjust Message and Image properties
    });
    // Combine and order
    var responses = likes.Concat(comments).OrderBy(x => x.Time);
    PostVM model = new PostVM()
    {
        ....
        Responses = responses
    };
    return View(model);
