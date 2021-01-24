    var q = (
            from blog in _context.Blogs
            from post in blog.Posts
            group blog by new
                          {
                              BlogId = blog.Id,
                              PostId = post.Id,
                              PostText = post.Text,
                          }
            into g
            where g.Count() >= 4
            select new 
                   { 
                       g.Key.BlogId, 
                       g.Key.PostId, 
                       g.Key.PostText 
                   }
            ).Take(4);
