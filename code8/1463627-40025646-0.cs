    var query = from o in orders
					where (o.Date == firstDate || o.Date == secondDate)
					group o by o.ItemID into g
					select new
                    {
                        ItemID = g.Key,
                        DateStart = g.ElementAt(0).Date,
                        DateEnd = g.ElementAt(1).Date,
                        Ratio = g.ElementAt(1).InStock / (float)g.ElementAt(0).InStock
                    };
