    query.GroupBy(c => c.Auctions)
         .Select (n => new 
                       {
                           Auction = n.Key,
                           AuctionCount = n.Count()
                       }
                  )
         .OrderBy(n => n.AuctionCount)
