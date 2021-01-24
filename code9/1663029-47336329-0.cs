    public ActionResult Details(int bookingId)
    {
        var booking = db.Bookings
            .Include(u => u.UserAccount)
            .Include(t => t.Taxi)
            .Include(s => s.BookingStatus)
            .Single(b => b.BookingId = bookingId);
        return View(booking);
    }
