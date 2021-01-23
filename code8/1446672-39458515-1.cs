    return View(await _context.Blogs
                              .Include(p => p.Posts)
                              .SelectMany(e=> e.Posts.Select(p=> new BlogsWithRelatedPostsViewModel
                                                                 {
                                                                  BlogId= e.BlogId,
                                                                  PostId=p.PostId,
                                                                  Url=e.Url,
                                                                  ...
                                                                 })
                              .ToListAsync()); 
