    if (!NHibernateUtil.IsInitialized(st.MasterKeyValuePairs))
    {
        var merged = ssw.Session.Merge(st);
        NHibernateUtil.Initialize(merged.MasterKeyValuePairs);
    }
