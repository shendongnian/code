    foreach (var item in items)
    {
        PropertyInfo piSite = item.GetType().GetProperty("Site");
        object site = piSite.GetValue(item,null);
        PropertyInfo piSiteName = site.GetType().GetProperty("SiteName");
        object siteName = piSiteName.GetValue(site, null);
        Console.WriteLine(siteName);
    }
