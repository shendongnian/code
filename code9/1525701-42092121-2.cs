    if (!String.IsNullOrEmpty(SYSID.ToString()))
    {
        query = query.Where(a => a.SysId.Equals(SYSID)); // only filter here
    }
    return query.Select(a => a.Name).ToList(); // now project the result finally
