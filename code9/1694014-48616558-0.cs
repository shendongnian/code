    public static IQueryable<IStore> StoreLite(IQueryable<IStore> dbSet)
    {
    	var result = dbSet
    		.Include(str => str.VATs)
    			.ThenInclude(vat => vat.VAT)
    				.ThenInclude(vat => vat.Culture)
    					.ThenInclude(cult => cult.Items)
    						.ThenInclude(itm => itm.Culture)
    		.Include(str => str.Options)
    			.ThenInclude(opt => opt.Items)
    				.ThenInclude(itm => itm.Option)
    		.Include(str => str.Cultures)
    			.ThenInclude(cult => cult.Items)
    				.ThenInclude(itm => itm.Culture)
    					.ThenInclude(cult => cult.Items)
    						.ThenInclude(itm => itm.Culture)
    		.Include(str => str.Pages)
    			.ThenInclude(page => page.Sections)
    				.ThenInclude(section => section.Elements);
    
    	return result;
    }
    
    public static IQueryable<IStore> Store(IQueryable<IStore> dbSet)
    {
    	var result = StoreLite(dbSet)
    		.Include(str => str.Categorys)
    			.ThenInclude(cat => cat.Products)
    				.ThenInclude(prd => prd.InfoItems)
    					.ThenInclude(itm => itm.Culture)
    						.ThenInclude(cult => cult.Items)
    							.ThenInclude(itm => itm.Culture);
    
    	return result;
    }
    
    public static IQueryable<IPage> Page(IQueryable<IPage> dbSet)
    {
    	var result = dbSet
    		.Include(page => page.Sections)
    			.ThenInclude(sec => sec.Elements)
    		.Include(page => page.CSS)
    		.Include(page => page.Script)
    		.Include(page => page.Meta);
    
    	return result;
    }
