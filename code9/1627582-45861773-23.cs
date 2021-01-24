    public async Task<IActionResult> Index(int page=1)
    {
        int pageSize = 10;
        var count = await _context.Agent.CountAsync();
        var items = await _context.Agent.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
     
        PageViewModel pageVm= new PageViewModel(count, page, pageSize);
        IndexViewModel vm= new IndexViewModel
        {
            PageViewModel = pageVm,
            Agents =items // need to create table in view from Agent properties
        };
        return View(vm);
    }
