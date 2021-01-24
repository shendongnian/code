    public async Task<IActionResult> TripTable(int? page)
    {
        var trips = from t in _tripcontext.Tripmetadata select t;
        int pageSize = 10;
        return PartialView("PartialTripsView", await PaginatedList<Tripmetadata>.CreateAsync(trips.AsNoTracking().OrderBy(t => t.Tripid), page ?? 1, pageSize));
    }
