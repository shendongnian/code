    public class XrmEnumerator<T> : IEnumerator<T> where T : Entity
    {
        private readonly Queue<T> _collected = new Queue<T>();
        private IOrganizationService _service;
        private QueryExpression _query;
        private string _lastCookie;
        private bool _moreRecords;
    
        public T Current { get; private set; }
        object IEnumerator.Current => Current;
    
        public XrmEnumerator(IOrganizationService service, QueryExpression query)
        {
            _service = service;
            _query = query;
            if (query.PageInfo == null)
                query.PageInfo = new PagingInfo
                {
                    Count = 5000,
                    PageNumber = 1
                };
            FillThePack();
        }
    
        private void FillThePack()
        {
            var result = _service.RetrieveMultiple(_query);
            _lastCookie = result.PagingCookie;
            result.Entities.ToList().ForEach(e=>_collected.Enqueue(e.ToEntity<T>()));
            _moreRecords = result.MoreRecords;
        }
    
        public void Dispose()
        {
            _service = null;
            _query = null;
        }
    
        public bool MoveNext()
        {
            if(_collected.Count == 0)
            {
                if (!_moreRecords)
                {
                    return false;
                }
                _query.PageInfo.PagingCookie = _lastCookie;
                _query.PageInfo.PageNumber++;
                FillThePack();
            }
            Current = _collected.Dequeue();
            return true;
        }
    
        public void Reset()
        {
            _query.PageInfo.PagingCookie = string.Empty;
            _query.PageInfo.PageNumber = 1;
        }
    }
    public class XrmEnumerable<T> : IEnumerable<T> where T : Entity
    {
        private readonly XrmEnumerator<T> _enumerator;
    
        public XrmEnumerable(IOrganizationService service, QueryExpression query)
        {
            _enumerator = new XrmEnumerator<T>(service, query);
        }
    
        public IEnumerator<T> GetEnumerator() => _enumerator;
            
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }
    
        public virtual void Add(T entity)
        {
            // do your code on item deserialization
        }
    }
