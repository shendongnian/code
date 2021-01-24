    public static IDictionary<string, IEnumerable<User>> AllCommonTags(this IEnumerable<User> users)
    {
         if (users == null) return null;
         return users.AllTags().Select(t => new
         {
             Tag = t, Users = users.WithTag(t)
         }).ToDictionary(ct => ct.Tag, ct => ct.Users);
    }
