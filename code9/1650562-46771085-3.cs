    static void Main(string[] args)
    {
        var connection = Effort.DbConnectionFactory.CreateTransient();
        using (var dbContext = new BloggingContext(connection))
        {
            var addedBlog = dbContext.Blogs.Add(new Blog[]
            {
                Name = "1",
                Posts = new Post[]
                { 
                    new Post() {Title = "1st", Content = "a"},
                    new Post() {Title = "2nd", Content = "b"},
                    new Post() {Title = "3rd", Content = "c"},
                },
            });
			dbContext.SaveChanges();
        }
        using (var dbContext = new BloggingContext(connection))
        {
            var allPosts = context.Posts.ToList();
            foreach (var post in allPosts)
            {
                Console.WriteLine($"{post.Id}: {post.Title}");
            }
        }
