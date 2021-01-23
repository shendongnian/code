    using (var ctx = _context)
    {
        var data = ctx.Restaurants
                .OrderBy(x => x.Address.Coordinates.Distance(coordinates))
                .Take(amountOfRestaurants)
                .Select(t=> new { Restaurant = t, Rating = ctx.Reviews.Where(c=>c.RestaurantId == t.Id).Select(c=>c.Rating).Avg()})
                .ToList();
        foreach(t in data)
        {
            t.Restaurant.AverageRating = t.Rating;
        }
    
        return data.Select(t=>t.Restaurant);
    }
