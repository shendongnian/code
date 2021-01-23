    IQueryable<Order_Travel> otQuery = _context.Order_Travels;
    if (profileId != 0)
    {
        otQuery = otQuery.Where(x => x.Profile.ProfileID == profileId);
    }
    if (timeSpan != null && timeSpan.Trim() != "")
    {
        otQuery = otQuery.Where(x => DbFunctions.TruncateTime(x.TimeRecieved) >= startDate &&
                                     DbFunctions.TruncateTime(x.TimeRecieved) <= endDate);
    }
 
