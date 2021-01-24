    var query = nhibernateSession
        .QueryOver<Demanda>(() => DemandaAlias);
    
    var someTestIfShouldApplyThisFilter = ...;
    if (someTestIfShouldApplyThisFilter)
    {
        query = query.Where(() => (DemandaAlias.ID == userId);
    }
