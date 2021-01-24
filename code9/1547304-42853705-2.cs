    public class PopularPostsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
    
        public PopularPostsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _context.Posts
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToListAsync();
    
            return View(posts);
        }
    }
