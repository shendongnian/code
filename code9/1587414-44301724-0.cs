    var query = db.Notify;
    query = query.Where(r => r.ApplicationId == applicationId);
    if (shouldCheckDate) {
        query = query.Where(r => r.CreatedDate.Date > date);
    }
    var result = query.Count();
