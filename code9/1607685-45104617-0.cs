    public ICollection<Aggregate> GetSortedAggregates(AggregateListFilter filter, out int rowCount)
    {
        var query = (base.Repository.CurrentSession() as ISession).QueryOver<Aggregate>();
        query = query.And(q => q.Status != StatusType.Deleted);
        if (!string.IsNullOrWhiteSpace(filter.Name))
            query = query.And(q => q.Name == filter.Name);
        rowCount = query.RowCount();
        switch (filter.OrderColumnName)
        {
            case ".Name":
                query = filter.OrderDirection == OrderByDirections.Ascending ? query.OrderBy(x => x.Name).Asc : query.OrderBy(x => x.Name).Desc;
                break;
            default:
                query = filter.OrderDirection == OrderByDirections.Ascending ? query.OrderBy(x => x.Id).Asc : query.OrderBy(x => x.Id).Desc;
                break;
        }
        if (filter.CurrentPageIndex > 0)
        {
            return query
            .Skip((filter.CurrentPageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .List();
        }
        return query.List();
    }
