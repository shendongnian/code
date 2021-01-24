    public class Repository : IRepository
    {
        static Repository()
        {
            QueryableExtensions.Includer
                = QueryableExtensions.Includer ?? new DbIncluder();
        }
        // ...
    }
