    IQueryable<Event> events = db.Events;
    
    if (myArray != null)
    {
        events = events
          .Include(a => a.AspNetUser)
          .Where(a=> myArray.Contains(a.AspNetUser.Id))
          .ToList()
          .OrderBy(a=>myArray.IndexOf(a.AspNetUser.Id));
    }
