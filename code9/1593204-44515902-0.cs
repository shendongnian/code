    // some test data
    var oUsers = Enumerable.Range(0, 100).Select(x => new { SubscriptionEnddate = (DateTime?)DateTime.Now.AddDays(x) });
    var rangeStart = DateTime.Now;
    var rangeEnd = rangeStart.AddDays(30);
    // Conditional count... can also be done as .Where(condition).Count()
    int Count = oUsers.Count(x => x.SubscriptionEnddate >= rangeStart && x.SubscriptionEnddate < rangeEnd);
