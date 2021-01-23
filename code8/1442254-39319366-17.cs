    using DatabaseUser = Databasel.User;
    public static class DatabaseUserExtensions
    {
        public static User ToModel(this DatabaseUser x)
        {
            //convert here and return
        }
        public static IEnumerable<User> ToModels(this IEnumerable<DatabaseUser> xs)
        {
            //replace with linq
            List<User> userList = new List<User>();
            foreach(var user in xs) 
            {
                userList.Add(user.ToModel());
            }
            return userList;
        }
    }
