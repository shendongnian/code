    public class BlogDTO 
    {
       public int Id {get; set;}
       public string Name {get; set;}
       public bool IsNotified {get; set;}
    }
    var qry = from b in _context.Blogs
              select new BlogDTO { Id = b.BlogId, Name = b.BlogName, IsNotified = b.IsNotified}; 
    return View(await qry.ToListAsync());
