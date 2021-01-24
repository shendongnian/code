    using Z.EntityFramework.Plus;
    [HttpGet("[action]")]
    public async Task<IActionResult> GetProjectsByDate()
    {
        try
        {
            var min = new DateTime(2017, 3, 1); 
            var max = new DateTime(2017, 3, 15);
            var projects = await context.Projects
                .IncludeFilter(p => p.Hours
                        .Where(w => w.WorkDate < max && w.WorkDate > min))
                .AsNoTracking()
                .ToListAsync(); 
             return Json(projects);
        }
    }
