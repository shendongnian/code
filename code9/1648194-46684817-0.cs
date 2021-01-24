    var allGroups = 
        ObjectFactory.GetInstance<IUnitOfWork>().Session
            .Query<Group>()
            .FetchMany(g => g.ChildGroups)
            .FetchMany(g => g.Vacancies)
            .Where(g => g.Deleted != "deletedgroup")
            .ToList();
