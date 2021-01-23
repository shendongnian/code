    public static class DatabaseUserExtensions
    {
        public static User ToModel(this Database.User x)
        {
            //convert the object of type Database.User to your User model clas here
        }
        public static IEnumerable<User> ToModels(this IEnumerable<Database.User> xs)
        {
            return xs.Select(x => x.ToModel());
        }
    }
