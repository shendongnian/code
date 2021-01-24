    class MyDbContext : DbContext
    {
        public DbSet<MyTSource> ExcludedUrls {get; set;}
    }
    void string Transform(MyTSource excludedUrl)
    {
        ...
    }
    List<string> result = dbContext.ExcludedUrls
        .Select(excludedUrl => Transform(excludedUrl)
        .ToList();
