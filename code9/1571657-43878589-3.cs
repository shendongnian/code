    db.Blogs.Local.Add(
        new Blog
        {
            Posts = new List<Post>
                    {
                        new Post(),
                        new Post(),
                    }
        }
    );
    db.SaveChanges();
    var query = db.Set<Post>().Count(); //Output will be 0
