    {
        // This will give you a list of IDs
        var RestaurantIDRestaurantTbl = db.Restaurants
            .Select(p => p.RestaurantID)
            .ToList();
        // Using .Any() is a better choice instead of .Contains()
        // .Contains is used to check if a list contains an item while .Any will look for an item in a list with a specific ID
        var listOfRestaurantsReservations = db.RestaurantReservationEvents
            .Where(p => RestaurantIDRestaurantTbl.Any(r => r.pRestaurantID == p))
            .ToList();
    } 
