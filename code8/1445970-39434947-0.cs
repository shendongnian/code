    using (var context = new BloggingContext()) 
    { 
      var post = context.Posts.Find(2); 
    
      // Load the blog related to a given post 
      context.Entry(post).Reference(p => p.Blog).Load(); 
    
      // Load the blog related to a given post using a string  
      context.Entry(post).Reference("Blog").Load(); 
    
      var blog = context.Blogs.Find(1); 
    
      // Load the posts related to a given blog 
      context.Entry(blog).Collection(p => p.Posts).Load(); 
    
      // Load the posts related to a given blog  
      // using a string to specify the relationship 
      context.Entry(blog).Collection("Posts").Load(); 
    }
