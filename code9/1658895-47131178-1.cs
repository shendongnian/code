    public bool Select(Expression<Func<DataAccess.Model.Group, bool>> Query, out List<Business.Entity.Login.LoginUser> Output)
    {
        IQueryable<DataAccess.Model.Group> Connection = GetQuery();
        Output = Connection.Where(Query).ToLoginUser().ToList();
        return true;
    }
