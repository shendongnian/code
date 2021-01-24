	var results = orders
		.Select (o => new {
			Order = o,
			LatestHistoryStatusOrder = o.HistoriesStatusOrder
				.OrderByDescending (hso => hso.Date)
				.First()
		})
		.Where (x => x.LatestHistoryStatusOrder.StatusOrderCode == "foobar")
		.Select (x => x.Order);
    foreach(var order in results)
    {
        // Here you can access:
        //  order.ID
    }
