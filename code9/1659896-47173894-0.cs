	public IList<Table1Entity> GetList(FilterParams filterParams = null, PageParams pageParams = null)
	{
		IList<Table1Entity> instance = null;
        Conjunction conjTable1 = Restrictions.Conjunction();
        Conjunction conjTable2 = Restrictions.Conjunction();
        if(filterParams == null)
            filterParams = new FilterParams();
        if(!string.IsNullOrEmpty(filterParams.Date))
            conjTable1.Add(Restrictions.Eq(Projections.Property<Table1Entity>(x => x.Date), filterParams.Date));
        if(!string.IsNullOrEmpty(filterParams.FromTime))
            conjTable1.Add(Restrictions.Eq(Projections.Property<Table1Entity>(x => x.FromTime), filterParams.FromTime));
        if(!string.IsNullOrEmpty(filterParams.ToTime))
            conjTable1.Add(Restrictions.Eq(Projections.Property<Table1Entity>(x => x.ToTime), filterParams.ToTime));
        if(!string.IsNullOrEmpty(filterParams.Id))
            conjTable1.Add(Restrictions.Eq(Projections.Property<Table1Entity>(x => x.Id), Guid.Parse(filterParams.Id)));
        if(!string.IsNullOrEmpty(filterParams.Pid))
            conjTable2.Add(Restrictions.Eq(Projections.Property<Table2Entity>(x => x.Pid), Guid.Parse(filterParams.Pid)));
        IQueryOver<Table1Entity> query = NHSession.QueryOver<Table1Entity>()
                    .Where(conjTable1)
                    .JoinQueryOver(x => x.Table2)
                    .And(conjTable2);
        if(pageParams != null)
            query = query.Skip(pageParams.SkipRecords).Take(pageParams.TakeRecords);
        instance = query.List();
		return instance;
	}
