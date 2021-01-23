	public static IEnumerable GetModelData(ApplicationDbContext context)
	{
		return context.Deliveries
			.GroupBy(x => new { x.Product.Id, x.Product.Name, Week = SqlFunctions.DatePart("wk", x.DeliveryDate) } )
			.Select(x => new
			{
				Id = x.Key.Id,
				Product = x.Key.Name,
				Week = x.Key.Week,
				Quantity = x.Sum(a => a.Quantity),
			})
			.AsEnumerable()
			.GroupBy(x => new { x.Id, x.Product })
			.Select(x => new
			{
				Id = x.Key.Id,
				Product = x.Key.Product,
				Wk1 = x.Sum(a => a.Week == 1 ? a.Quantity : 0),
				Wk2 = x.Sum(a => a.Week == 2 ? a.Quantity : 0),
				Wk51 = x.Sum(a => a.Week == 52 ? a.Quantity : 0),
				Wk52 = x.Sum(a => a.Week == 53 ? a.Quantity : 0),
			})
			.ToList();
	}
