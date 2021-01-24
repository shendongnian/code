    private static readonly IReadOnlyDictionary<string, Type> MyTypeMap 
    = new Dictionary<string, Type>
    {
        { "users", typeof(Users)},
        { "foo", typeof(Foo)},
        ... other type maps here
    };
    public async Task<IEnumerable<object>> WeakQuery(string someType, string someQuery)
    {
        Type typeOfMyClass;
        if (MyTypeMap.TryGetValue(someType, out typeOfMyClass))
        {
            using (var db = new DbContext(ConnString))
            {
                return await db.Database.SqlQuery(typeOfMyClass, someQuery)
                    .ToListAsync()
                    .ConfigureAwait(false);
                // The problem now is that you get an untyped DbRawSqlQuery
            }
        }
        return Enumerable.Empty<object>();
    }
