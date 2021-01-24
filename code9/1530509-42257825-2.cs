    if(!db.Bookings.Any(b=>b.ScheduleID == booking.ScheduleID 
                       && b.ScheduleID == booking.ScheduleID))
    {
        db.Bookings.Add(booking);
        db.SaveChanges();
        DisplaySuccessMessage("Has append a Booking record");
        return RedirectToAction("BookingIndex");
    }
