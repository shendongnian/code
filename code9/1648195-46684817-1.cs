    var activeGroupIds = 
        ObjectFactory.GetInstance<IUnitOfWork>().Session
            .Query<Group>()
            .Where(g => g.Deleted != "deletedgroup")
            .Select(g => g.Id);
    var allGroups = 
        ObjectFactory.GetInstance<IUnitOfWork>().Session
            .Query<Group>()
            .FetchMany(g => g.ChildGroups)
            .FetchMany(g => g.Vacancies)
            .Where(g => activeGroupIds.Contains(g.Id))
            .ToList();
