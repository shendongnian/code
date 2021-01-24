	public List<Deal> GetEventsDeals()
	{
	    var deals = DataContext.Deals.Join(DataContext.Businesses,
	        d => d.BusinessId,
	        b => b.Id,
	        (d, b) => new Deal(){Business = b, Deal = d})
	        .Where(d => (d.Deal.IsEvent == true));
	    return deals.OrderBy(d => d.Deal.Order).Take(50).ToList();
	}
