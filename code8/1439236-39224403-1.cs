    using (ApplicationDbContext db = new ApplicationDbContext())
    {
        var query = db.PageStats
            .Where(x => x.Date >= vm.StartDate && x.Date <= vm.EndDate);
    
        if (!vm.CMS.Equals("All"))
            query = query.Where(x => x.Source.Equals(vm.CMS));
        if (!vm.HealthCenter.Equals("All"))
            query = query.Where(x => x.HealthSectionName.Equals(vm.CMS));
        if (!vm.Country.Equals("All"))
            query = query.Where(x => x.Country.Equals(vm.CMS));
        if (!vm.City.Equals("All"))
            query = query.Where(x => x.City.Equals(vm.CMS));
    
        query = query
            .GroupBy(x => x.Date)
            .Select(g => new
            {
                Date = g.Key,
                Total = g.Sum(x => x.PageViews)
            })
            .OrderBy(x => x.Date);
    
        var pageViewStats = query
            .AsEnumerable() // SQL query ends here
            .Select(x => new PageViews
            {
                Date = x.Date.Value.ToShortDateString(),     
                Total = x.Total
            })
            .ToList();
    
        return pageViewStats;
    }
