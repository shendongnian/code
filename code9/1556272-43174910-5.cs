    var site = _context.Site.Single(j => j.Site.SiteID==id);
    var jobs = from j in _context.Job
        //.Include(j => j.Site) -- this can be removed
        .Include(j=>j.WaterBody)
        .Where(j=>j.Site.SiteID==id)
        .OrderByDescending(j=>j.BookingDate)
        select j;
    return View(new SiteJobsHistoryModel
        {
            Site = site,
            Jobs = await PaginatedList<Job>.CreateAsync(jobs.AsNoTracking(), page ?? 1, pageSize)
        });
