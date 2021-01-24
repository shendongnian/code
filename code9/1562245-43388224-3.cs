	var results = orders
		.Select (o => new {
			Order = o,
			LatestHistoryStatusOrder = o.HistoriesStatusOrder
				.OrderByDescending (hso => hso.Date)
				.First()
		})
		.Where (x => x.LatestHistoryStatusOrder.StatusOrderCode == "foobar");
    foreach(var item in results)
    {
        // Here you can access:
        //   item.Order.ID
        //   item.LatestHistoryStatusOrder
    }
