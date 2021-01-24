	private IEnumerable<PageInfo> GetPageList(HttpContextBase httpContext)
	{
		string key = "__CustomPageList";
		var pages = httpContext.Cache[key];
		if (pages == null)
		{
			lock (synclock)
			{
				pages = httpContext.Cache[key];
				if (pages == null)
				{
					pages = new List<PageInfo>()
					{
						new PageInfo()
						{
							VirtualPath = string.Format("{0}/Contact", BookingEngine.Route),
							Controller = "Home",
							Action = "Contact"
						},
					};
					httpContext.Cache.Insert(
						key: key,
						value: pages,
						dependencies: null,
						absoluteExpiration: System.Web.Caching.Cache.NoAbsoluteExpiration,
						slidingExpiration: TimeSpan.FromMinutes(1),
						priority: System.Web.Caching.CacheItemPriority.NotRemovable,
						onRemoveCallback: null);
				}
			}
		}
		return (IEnumerable<PageInfo>)pages;
	}
	
