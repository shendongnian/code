    var searchTrip = indexControllerViewData.SearchTrip;
    var trips = db.Trips;
    
    if (!string.IsNullOrEmpty(searchTrip.From))
    {
        trips.Where(u => u.From.Contains(searchTrip.From))
    }
    if (!string.IsNullOrEmpty(searchTrip.To))
    {
        trips.Where(u => u.To.Contains(searchTrip.To))
    }
    // ... and so on
