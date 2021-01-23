    var searchDict = new Dictionary<Func<SearchCriteria, bool>, Func<IQueryable<?>, IQueryable<?>>>()
    {
        { c => c.EventReference != null, q => q.Search(x = > x.EventReference, searchCriteria.EventReference)},
        { c => c.VerifiedEvent == false, q => q.Where(x = > x.EventStatusId != EventStatus.Verified) },
        { c => c.RemitterId != null, q => q.Where(x = > x.Trade.RemitterId == searchCriteria.RemitterId) },
        ...
    };
    foreach (var item in seachDict)
        if (item.First(searchCriteria))
            query = item.Second(query);
