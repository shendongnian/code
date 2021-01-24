    var subscription = producer
            .TakeWhile(ei => ei.Id != 42)
            .GroupBy(x => x.Name)
            .Select(o => o)
            .SelectMany(o => o.ToList()) //If you want y to be IList<EventItem>, use this line. If you prefer y to be IObservable<EventItem>, comment out.
            .Repeat()
            .Subscribe();
