    using (var db = new BloggingContext())
    {
        // If using Code First we need to make sure the model is built before we open the connection
        // This isn't required for models created with the EF Designer
        db.Database.Initialize(force: false);
        // Create a SQL command to execute the sproc
        var cmd = db.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[GetAllBlogsAndPosts]";
        try
        {
            
            db.Database.Connection.Open();
            // Run the sproc 
            var reader = cmd.ExecuteReader();
            // Read Blogs from the first result set
            var blogs = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Blog>(reader, "Blogs", MergeOption.AppendOnly);   
            foreach (var item in blogs)
            {
                Console.WriteLine(item.Name);
            }        
            // Move to second result set and read Posts
            reader.NextResult();
            var posts = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Post>(reader, "Posts", MergeOption.AppendOnly);
            foreach (var item in posts)
            {
                Console.WriteLine(item.Title);
            }
        }
        finally
        {
            db.Database.Connection.Close();
        }
    }
