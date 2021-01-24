    IQueryable<Event> events = db.Events;
    
    if (myArray != null)
    {
        events = events
          .Include(a => a.AspNetUser)
          .Where(a=> myArray.Contains(a.AspNetUser.Id));
    }
