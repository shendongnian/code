    public class WhereEventStatusQueryFilter : AQueryFilter<bool>
    {
        private EventStatus _toTest;
        public WhereEventStatusQueryFilter(Func<SearchCriteria, bool> criteria, EventStatus toTest)
            : base(criteria)
        {
            _toTest = toTest;
        }
        public override IQueryable<Whatever> Filter(IQueryable<Whatever> query, SearchCriteria searchCriteria)
        {
            return (Criteria(searchCriteria) ? query : query.Where(x => x.EventStatusId != _toTest));
        }
    }
    public class SearchQueryFilter : AQueryFilter<object>
    {
        Func<Whatever, object> _searchFor;
        public SearchQueryFilter(Func<SearchCriteria, object> criteria, Func<Whatever, object> searchFor)
            : base(criteria)
        {
            _searchFor = searchFor;
        }
        public override IQueryable<Whatever> Filter(IQueryable<Whatever> query, SearchCriteria searchCriteria)
        {
            return (Criteria(searchCriteria) == null ? query : query.Search(x => _searchFor(x), Criteria(searchCriteria)));
        }
    }
    public class WhereEqualQueryFilter : AQueryFilter<object>
    {
        Func<Whatever, object> _searchFor;
        public WhereEqualQueryFilter(Func<SearchCriteria, object> criteria, Func<Whatever, object> searchFor)
            : base(criteria)
        {
            _searchFor = searchFor;
        }
        public override IQueryable<Whatever> Filter(IQueryable<Whatever> query, SearchCriteria searchCriteria)
        {
            return (Criteria(searchCriteria) == null ? query : query.Where(x => _searchFor(x) == Criteria(searchCriteria)));
        }
    }
