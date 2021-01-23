    var eventNumbers = EventNumbers.Where(e => e.Active).OrderBy(e => e.Event_Number).ToList();
    foreach (var en in EventNumbers)
    {
	    Console.WriteLine($"EventNumber: {en.Event_Number}");
	
        var results = Results
		.Where(r => r.EntryEvent.EventNumberId == en.Id && !r.Disqualified && r.Active && !r.EntryEvent.Scratched)
		.OrderBy(r => r.AdjustedTime)
		.Take(20);
	    if (results != null)
	    {
		    foreach (var result in results)
		    {
			    Console.WriteLine($"Time: {result.AdjustedTime}");
		    }
	    }
    }
