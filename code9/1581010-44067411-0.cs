    public IEnumerable<TrackedReportData> GetUnused(TimeSpan cacheExpiration)
    {
        return Session
            .QueryOver<TrackedReportData>()
            .Where(t => t.CacheSize > 0)
            .Where(Restrictions.Or(
                Restrictions.On<TrackedReportData>(t => t.LastAccessDate).IsNull,
                Restrictions.Where<TrackedReportData>(
                    t => t.LastAccessDate < DateTime.Now.Add(-cacheExpiration))))
            .List();
    }
