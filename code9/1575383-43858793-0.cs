    var carId = 1;
    var result = db.Bookings
        .Where(booking => booking.CarID == carId)
        .Select(b => new { StartDate = b.StartDate, EndDate = b.EndDate })
        .ToList();
