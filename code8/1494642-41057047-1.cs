    public static List<_Account> Get(_User user, Context contextProvided = null, string name = null, SearchType sName = SearchType.Equals)
    {
      using (Context contextInner = (c == null ? new Context() : null)) //magic here
      {
        Context context = contextProvided ?? contextInner; //magic here
        IQueryable<_Account> query = context.Accounts;
        if (!string.IsNullOrEmpty(name) && sName == SearchType.Equals)
          query = query.Where(r => r.Name.Equals(name));
        if (!string.IsNullOrEmpty(name) && sName == SearchType.StartsWith)
          query = query.Where(r => r.Name.StartsWith(name));
        if (!string.IsNullOrEmpty(name) && sName == SearchType.Contains)
          query = query.Where(r => r.Name.Contains(name));
        return query.ToList();
      }
    }
