    public Task<SiteTemplateResource[]> GetResources(int siteTemplateId, string extension)
    {
        return Database.FindBy<SiteTemplateResource>(str => 
                               str.SiteTemplateId == siteTemplateId 
                               && str.HashedFile.EndsWith(extension))
                       .ToArrayAsync();
    }
