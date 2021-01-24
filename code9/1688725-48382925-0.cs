    var indexedPriorities = priorities.Select( (priority, index) => new
    {
        Priority = priority,
        OrderIndex = index,
    });
    var result = GetNearbyPeopleList()
        .Where(...)                          // take only people you want
        .Join(indexedPriorities,             // join with indexedPriorities
        people => people.CurrentLocation,    // from each people take the CurrentLocation
        indexedPrio => indexedPrio.Priority, // from each indexedPriority take the priority
        (people, prio) => new                // when they match, make a new object
        {
            Index = prio.Index,              // containing the index of the matching priority
            People = people,                 // and the matching data
        })
        .OrderBy(item => item.Index)         // order by ascending index
        .Select(item => item.People);        // keep only the People
        
