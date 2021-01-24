    var siteData = (
                from site in db.Site
                join cust in db.Customer on site.SiteID equals cust.SiteID
                group cust by site into g
                from subCust in g.DefaultIfEmpty()
                select new vm_SiteList
                {
    
                    SiteName = subCust?.Key.SiteName ?? string.Empty,
                    Customers = g.Count()
    
                }).ToList();
