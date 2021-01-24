    public IQueryable<YourClass> GetFeedbacks()
    {    
        var db = new TravelPlannerContext();
        var query = from booking in db.Bookings
                    group booking by booking.PackageId into grouping
                    select new YourClass // Now you are projecting the expected type
                    {
                        PackId = grouping.Key,
                        AverageRating = grouping.Average(ed => ed.Rating)
                    };
         return query;
    }
