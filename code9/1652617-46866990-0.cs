    foreach (var item in items)
    {
       YourNamespace.Site site = (YourNamespace.Site)item.GetType().GetProperty("Site").GetValue(item,null);
       Console.WriteLine(site.SiteName);
    }
