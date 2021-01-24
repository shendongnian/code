    public class FooController : Controller
    {
        public IEnumerable<Foo> GetAll( GetAllArgs args ) 
        {
            IQueryable<Foo> query = ...
            return query.Paginate( args ).ToList();  
        }
        public class GetAllArgs : QueryArgsBase
        {
            public string Filter { get; set; }
            public string Whatever { get; set; }
        }
    }
    public interface IPaginationInfo
    { 
        int PageNumber { get; }
        int PageSize { get; }
    }
    public abstract class QueryArgsBase : IPaginationInfo
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>( 
            this IQueryable<T> source, 
            IPaginationInfo pagination )
        {
            return source
                .Skip( ( pagination.PageNumber - 1 ) * pagination.PageSize )
                .Take( pagination.PageSize );
        }
    }
