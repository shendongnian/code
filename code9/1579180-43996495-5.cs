    public Task<int> SiteTemplateBySiteIdAsync(int siteId)=>
        Database.Where(sst => sst.SiteId == siteId)
                .Select(it=>it.SiteTemplateId)
                .FirstAsync();
    }
