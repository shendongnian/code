    using (var dataContext = new DataContext())
    {
        var x = dataContext.Events
            .Where(x => x.EventID == 10)
            .Select(x => new EventInfo()
            {
                  EventName = x.Name,
                  EventDateRange = $"{x.StartDate} - {x.EndDate}"
            })
            .FirstOrDefault();
    }
    if (x == null) {
        // there was no result
    }
    else {
        // Result found, and x is EventInfo
    }
