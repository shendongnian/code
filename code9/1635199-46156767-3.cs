    var sessionsToRemove = Session.Keys.Cast<string>().ToList();
    foreach (var key in sessionsToRemove)
    {
        Session.Remove(key);
    }
