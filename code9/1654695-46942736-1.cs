            var offers = new List<Offer>();
            // flatten the nested list linq-style
            var flat = from x in offers
                from y in x.OfferBands
                select new {x.TradingDate, x.HourOfDay, x.ProductName, y.Price, y.Quantity};
            var grouped = from x in flat
                group x by new {x.TradingDate, x.HourOfDay, x.ProductName}
                into g
                select new
                {
                    g.Key.TradingDate,
                    g.Key.HourOfDay,
                    g.Key.ProductName,
                    OfferBands = (from y in g
                        group y by new {y.Price}
                        into q
                        select new {Price = q.Key, Quantity = q.Sum(_ => _.Quantity)}).ToList()
                };
            foreach (var item in grouped)
            {
                Console.WriteLine(
                        "TradingDate = {0}, HourOfDay = {1}, ProductName = {2}",
                        item.TradingDate,
                        item.HourOfDay,
                        item.ProductName);
                foreach (var offer in item.OfferBands)
                    Console.WriteLine("    Price = {0}, Qty = {1}", offer.Price, offer.Quantity);
            }
