    using DatabaseUser = Database.User;
    public static class DatabaseUserExtensions
    {
        public static User ToModel(this DatabaseUser x)
        {
            //convert the object of type Database.User to your User model clas here
        }
        public static IEnumerable<User> ToModels(this IEnumerable<DatabaseUser> xs)
        {
            return xs.Select(x => x.ToModel());
        }
    }
