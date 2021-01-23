    [HttpPost]
    public async Task<ActionResult> EditBooking(BookingViewModel postData) {
        var existingBooking = await _db.Bookings.FindAsync(postData.BookingId);
        existingBooking.ActualCheckIn  = postData.ActualCheckIn;
        // ...
    }
