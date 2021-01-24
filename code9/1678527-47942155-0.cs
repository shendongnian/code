    var blogs = _context.Blogs.Include(x => x.Posts)
        .Where(x.Posts.Count >= 4)
        .ProjectTo<BlogVm>()
        .Select(x => new
        {
            Blog = x,
            //Take newly published 3 posts for per Blog
            RecentlyPosts = x.Posts.OrderByDescending(y => y.Published).Take(3)
        });
