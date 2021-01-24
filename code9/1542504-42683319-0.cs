    using (SPSite siteCollection = new SPSite(SiteCollectionUrl))
    {
        using(SPWeb parentSite = siteCollection.OpenWeb())
        {
           foreach (SPWeb subsite in parentSite.Webs)
           {
                // do something with subsite here
                subsite.Dispose();
           }
        }
        siteCollection.Dispose();
    }
