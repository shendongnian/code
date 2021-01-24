    public sealed class SingleResult<T> : SingleResult
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Web.Http.SingleResult`1 class.
        //
        // Parameters:
        //   queryable:
        //     The System.Linq.IQueryable`1 containing zero or one entities.
        public SingleResult(IQueryable<T> queryable);
        //
        // Summary:
        //     The System.Linq.IQueryable`1 containing zero or one entities.
        public IQueryable<T> Queryable { get; }
    }
