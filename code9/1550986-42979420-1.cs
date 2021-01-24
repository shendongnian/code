	[HttpGet("[action]")]
	public async Task<IActionResult> GetProjectsByDate()
	{
	    try
	    {
	        var min = new DateTime(2017, 3, 1); 
	        var max = new DateTime(2017, 3, 15);
	        var projects = await context.Projects
	            .Include(p => p.Hours)
	            .Where(p => p.Hours.Any() && p.Hours.Where(w => w.WorkDate < max && w.WorkDate > min).Count() == p.Hours.Count)
	            .AsNoTracking()
	            .ToListAsync(); 
	         return Json(projects);
	    }
	}
