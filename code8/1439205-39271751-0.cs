    results = context.GetQueryable<SearchResultItem>()
                 .Where(item => item.TemplateId == GlobalId.UniversalContent
                         || item.TemplateId == GlobalId.UniversalHome)
                 .Where(item => item.Path.Contains("/sitecore/content"))
                 .Select(i => (Item)i.GetItem()).ToList();
