    var sites = cn.Query(sql, (Site site, Location loc) => new { site, loc }, splitOn: "LocationID")
    	.GroupBy(e => e.site.SiteID)
    	.Select(g =>
    	{
    		var site = g.First().site;
    		site.Locations = g.Select(e => e.loc).Where(loc => loc != null).ToList();
    		return site;
    	})
    	.ToList();
