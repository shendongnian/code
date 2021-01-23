    internal static class MyClass2
    {
        public static IQueryable<T> ContainsAnyWord<T>(this IQueryable<T> value, string searchFor) where T: User
        {
            var names = searchFor.Split(' ').ToList();
            return value.Where(u => names.Contains(u.DisplayName));
        }
    }
