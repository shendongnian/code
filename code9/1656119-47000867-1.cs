    private static readonly IReadOnlyDictionary<string, Type> MyTypeMap = 
    new Dictionary<string, Type>
    {
        { "users", typeof(Users)},
        { "foos", typeof(Foos)},
        ..
    };
    public void SomeMethod(string someType)
    {
        using (var db = new DbContext("myConnString"))
        {
            Type typeOfMyClass;
            if (MyTypeMap.TryGetValue(someType, out typeOfMyClass))
            {
              var result = db.Database.SqlQuery(typeOfMyClass, "SELECT * FROM Users");
              ...
             }
        }
    }
