    using DatabaseUser = Databasel.User;
    public static class DatabaseUserExtensions
    {
        public static User ToModel(this DatabaseUser x)
        {
            //convert here and return
        }
        public static IEnumerable<User> ToModels(this IEnumerable<DatabaseUser> xs)
        {
            return xs.Select(x => x.ToModel());
        }
    }
