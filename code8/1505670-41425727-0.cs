    public static class Extensions
    {
        public static IMongoCollection<T> Items<T>(this IMongoDatabase database)
        {
            return database.GetCollection<T>(typeof(T).Name);
        }
        public static IMongoCollection<Student> Students(this IMongoDatabase database)
        {
            return database.Items<Student>();
        }
    }
	
