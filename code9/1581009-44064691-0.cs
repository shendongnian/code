    return Session
        .QueryOver<TrackedReportData>()
        .Where(t => t.CacheSize > 0)
        .Where(
            Restrictions.Lte(
                Projections.SqlFunction(
                    new VarArgsSQLFunction("(", "-", ")"),
                    NHibernateUtil.DateTime,
                    Projections.Property(t => t.LastAccessDate),
                    Projections.Constant(DateTime.Now)),
                cacheExpiration);
