    var searchDict = new Dictionary<Func<bool>, Func<IQueryable<?>>>()
    {
        { () => searchCriteria.EventReference != null, query.Search(x = > x.EventReference, searchCriteria.EventReference) },
        { () => searchCriteria.VerifiedEvent == false, query.Where(x = > x.EventStatusId != EventStatus.Verified) },
        { () => searchCriteria.RemitterId != null, query.Where(x = > x.Trade.RemitterId == searchCriteria.RemitterId) },
        ...
    };
    foreach (var item in seachDict)
        if (item.First())
            query = item.Second();
