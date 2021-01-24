    Predicate<YourType> a = e => e.IdWebsite == request.WebSiteId &&
                                                e.FulltextFree != null &&
                                                e.DataOra >= (System.DateTime.Today.AddDays(-60).Date);
    Predicate<YourType> b = e => e.UserId == request.UserId;
    var entitiesByUser = repository.Query(c => c.Where(Helpers.And(a, b)));
