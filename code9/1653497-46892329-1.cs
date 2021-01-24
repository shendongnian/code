    List<Menu> orderedItems = menuRepository
        .GetAll(x => x.SiteId == _siteConfiguration.Id && x.Active == true)
        .ToList()
        .ForEach(m => 
        {
            m.MenuHeaders = m.MenuHeaders.OrderBy(d => d.DisplayOrder);
            m.MenuCategories = m.MenuCategories.OrderBy(d => d.DisplayOrder);
            m.MenuOptionHeaders = m.MenuOptionHeaders.OrderBy(d => d.DisplayOrder);
        });
