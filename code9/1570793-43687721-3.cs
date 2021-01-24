    public static IEnumerable<User> WithTag(this IEnumerable<User> users, string tag)
    {
         if (users == null) return null;
         return users.Where(u => u.Tags.Contains(tag));
    }
