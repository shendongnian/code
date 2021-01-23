    public IEnumerable<MenuItem> GetAllMenuItems() =>
        _context.MenuItems.OfType<ArticleMenuItem>().Include(e => e.Article)
        .AsEnumerable() // to avoid runtime exception (EF Core bug)
        .Concat<MenuItem>(
        _context.MenuItems.OfType<PageMenuItem>().Include(e => e.Page));
