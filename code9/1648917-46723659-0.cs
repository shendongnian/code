    IList<SectionName> sections = SectionRepository.GetAll(name => name.SectionsSuffix, 
    name => name.SectionsSuffix.Select(suffix => suffix.SectionLines)).ToList();
    public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable query = includes.Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include));
        return (IEnumerable<T>) query;
    }
