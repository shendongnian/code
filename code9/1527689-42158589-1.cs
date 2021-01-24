    public IQueryable<YourClass> GetFeedbacks()
    {    
        return from booking in (new TravelPlannerContext()).Bookings
               group booking by booking.PackageId into grouping
               select new YourClass // Now you are projecting the expected type
               {
                   PackId = grouping.Key,
                   AverageRating = grouping.Average(ed => ed.Rating)
               };
    }
