    var actorsQuery =
        from a in usersQuery.Concat(groupsQuery)
        group a by new { a.Actor, a.Type } into g
        select new RoleActor
        {
            Actor = g.Key.Actor,
            Type = g.Key.Type,
            RoleNames = g.Select(a => a.Role.Name).ToList()
        };
