    if(!db.Bookings.Any(b=>b.ScheduleID == booking.ScheduleID 
                       && b.StaffID== booking.StaffID))
    {
        db.Bookings.Add(booking);
        db.SaveChanges();
        DisplaySuccessMessage("Has append a Booking record");
        return RedirectToAction("BookingIndex");
    }
