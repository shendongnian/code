    public ActionResult Comment(PostIndexViewModel model)
        {
            var userName = User.Identity.Name;
            var author = db.Users.SingleOrDefault(x => x.UserName == userName);
    
            Comment newPost = new Comment();
    
            newPost.Author = author;
            newPost.Text = model.Text;
            newPost.Post = model.Post;
    
    
            db.Comments.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("ShowBlogs", "Blog");
    
        }
