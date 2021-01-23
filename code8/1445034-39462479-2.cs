    private static string GetQueryString(string firstName)
    {
        return String.Format($"SELECT * FROM dbo.Person WHERE FirstName LIKE {firstName}");
    }
    public static partial class DbContextExtensions
    {
        public static List<QueryResult> GetEntriesThatStartWith(this DbContext context, string firstName)
        {
            return context.Database.SqlQuery<QueryResult>(GetQueryString(firstName)).ToList();
        }
    }
