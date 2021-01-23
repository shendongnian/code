    public async Task<List<Blog>> GetBlogsAsync()
            {
                using (var context = new BloggingContext())
                {
                    return await context.Blogs.ToListAsync();
                }
            }
