    using(var t = session.BeginTransaction(IsolationLevel.Serializable))
    {
        Coverage coverage = session.QueryOver<Coverage>()
            .Where(g => g.Description == description)
            .Take(1).SingleOrDefault();
        if (coverage == null)
        {
            coverage = new Coverage { Description = description };
            session.Save(coverage);
        }
        t.Commit();
        return coverage;
    }
