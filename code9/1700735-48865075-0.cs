    var result = db.Events                   // from all events
        .Where(event => event.Id == eventId) // take only the ones with Id == eventId
        .Select(event => new                 // from every remaining event,
        {                                    // select the following properties:
            // select only the properties you plan to use, for instance:
            Name = event.Name,
            Description = event.Description,
            // from the one and only parent, select the properties you plan to use
            Parent = new
            {
                Name = event.ParentObject.Name,
                Security = event.ParentObject.Security, 
            },
            EventItems = event.EventItems
                .Where(eventItem => eventItem.Severity > high)
                .Select(eventItem => new
                {
                     // again: only the properties you use!
                })
                .ToList(),
        })
        .SingleOrDefault();
