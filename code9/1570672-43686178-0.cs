    using(var t = session.BeginTransaction(IsolationLevel.Serializable))
    {
        Coverage coverage = session.QueryOver<Coverage>()
            .Where(g => g.Description == description)
            .Take(1).SingleOrDefault();
        if (coverage == null)
        {
            session.Save(new Coverage { Description = description });
        }
        t.Commit();
        return coverage;
    }
