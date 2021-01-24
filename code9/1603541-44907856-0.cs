    var result = (from event1 in _eventRepository
                  join event2 in _eventRepository on event1.Id equals event2.ParentId
    
                  group new {
                  	EventId =  event2.EventId,
                  	TimeInSeconds = DbFunctions.DiffSeconds(event1.CreationDate, event2.CreationDate)
                  }
                  by event2.EventTypeId into g
    
                  select new EventModel {
                  	EventTypeId = g.Key,
                  	NumberOfEvents = g.Count(),
                  	Time = (int) g.Average(x => x.TimeInSeconds)
                  }).ToList();
