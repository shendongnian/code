	private static TodayStatsItem GetStatsValue<TOrderBy>(Expression<Func<PlayerItem, bool>> filter,
    Expression<Func<PlayerItem, TOrderBy>> orderBy, IEnumerable<PlayerItem> items, string desc)
	{
    	Func<PlayerItem, TOrderBy> orderByDeleg = orderBy.Compile();
    	var itemSorted = new TodayStatsItem {
        PlayerItems = items.AsQueryable().OrderBy(orderByDeleg).Select(x => new TodayStatsViewModel
        	{
            	Name = x.Name,
            	StatValue = orderByDeleg(x)
        	}),
        	StatName = desc
    	};
    	return itemSorted;
	}
