    using (var dbContext = new MyDbContext())
    {
        var result = dbContext.PromotionalOffers
            .Where(promotionalOffer => promotionalOffer.ISVCSPID == 10)
            .Select(promotionalOffer => new
            {   // select only the properties you will be using:
                ISVCSPID = promotionalOffers.ISVSPID,
                ... // other properties from promotionalOffers
                PromotionalOffersUsed = promotionalOffers.PromtionalOffersUsed
                    .Where(promotionalOffersUsed => promotionalOffersUsed.OfferId == null)
                    .Select(promotionalOffersUsed => new
                    {
                         // again: select only the properties of PromotionalOffersUsed
                         // that you will be using
                         Id = promotionalOffersUsed.Id,
                         ... // other properties
                    })
                    .ToList();
            }
    }
