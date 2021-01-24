    public class AuctionViewModel
    {
        public List<Auction> mostPopularItems {get; set; }
        public List<Auction> endingSoon {get; set; }
    
            public AuctionViewModel(AuctionsDataContext db)
            {
                mostPopularItems = db.Auctions.Where(x => x.EndTime > DateTime.Today).OrderByDescending(x => x.viewCount).ToList();
                endingSoon = db.Auctions.Where(x => x.EndTime > DateTime.Today).OrderByDescending(x => x.EndTime).ToList();
            }
       }
    }
