    public void Add_writes_to_database()
    {
        var options = new DbContextOptionsBuilder<BloggingContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;
        using (var context = new BloggingContext(options))
        {
            var service = new BlogService(context);
            service.Add("http://sample.com");
        }
    }
