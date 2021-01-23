    public abstract class AQueryFilter<T> : IQueryFilter
    {
        public AQueryFilter(Func<SearchCriteria, T> criteria)
        {
            Criteria = criteria;
        }
        protected Func<SearchCriteria, T> Criteria { get; }
        public abstract IQueryable<Whatever> Filter(IQueryable<Whatever> query, SearchCriteria searchCriteria);
    }
