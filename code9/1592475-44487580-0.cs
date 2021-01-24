    // Join aliases for ease of getting access to all parts of the query
    VisitorVisit visitorVisitAlias = null;
    Visit visitAlias = null;
    VisitorLayEntryPoints = visitorLayEntryPointsAlias = null;
    
    IList<int> locationIds =
      session.QueryOver<VisitorVisit>()
        .JoinAlias(() => visitorVisitAlias.VisitId, () => visitAlias)
        .JoinAlias(() => visitAlias.VepId, () => visitorLayEntryPointsAlias)
        // Depends on where your LocId is
        .Select(() => visitorVisit.LocId)
        
        // I assumed your LocId is an int, switch to string if it's a string
        .List<int>();
