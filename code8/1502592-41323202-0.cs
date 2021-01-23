	var data = (from gp in test
				group gp by gp.Seller into g
				select new GroupedItem
				{
					Seller = g.Key,
					_Date = g.First()._Date,
					Sales = g.Sum(x => x.Sales),
					TransactionPrice = g.Sum(x => x.TransactionPrice)
				}).ToList();
	var best = data.Max(x => x.TransactionPrice);
	var worst = data.Min(x => x.TransactionPrice);
