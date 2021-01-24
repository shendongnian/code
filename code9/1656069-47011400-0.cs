    using System.Data.Entity;
    List<Listing> result = dbContext.Listings
        .Include(listing => listing.Lot)
        .Where(listing => listing.communityId == communityId)
        .ToList();
