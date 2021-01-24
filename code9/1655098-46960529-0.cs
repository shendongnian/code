    public class MyService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public MyService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public IEnumerable<Blogs> GetBlogs()
        {
            using (var scope = _scopeFactory.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MyDbContext>())
            {
                return context.Blogs
                              .Include(blog => blog.Posts)
                              .ToList();
            }
        }
    }
