        var allTours= 
            from p in _context.PostsInfo  //Why this doesn't return two records
            join r in _context.Region
            on p.RegionId equals r.Id
            where r.CountryId == 1
            select new PostAndRegion
            {
              Region = r.CountryId,
              Post= p.ImageName,
            };
        var model = new MyCompositeModel 
        {
             PostsAndRegions = allTours.ToArray(),
             UserInfo = null // or get from where you want to
        };
        return View(model);
