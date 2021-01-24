    public void ValidateCapacity(Booking booking)
    {
        var restaurant = dal.GetRestaurant(booking.IDRestaurant);
        var existingBookings = dal.GetBookings(booking.IDRestaurant, booking.Date);
        var available = restaurant.Size - existingBookings.Sum(b => b.Nbpeople);
        if (booking.Nbpeople > available)
        {
            ModelState.AddModelError("Nbpeople", "There is not enough capacity at the restaurant for this many people on the date you've selected");
        }
    }
