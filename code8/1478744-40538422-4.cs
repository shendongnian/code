    public static IQueryable<User> WhereContainsAnyWord(this IQueryable<User> @this, string searchFor)
    {
        var tags = StopwordTool.GetPossibleTags(searchFor); //You might need a .ToArray() here.
        return @this.Where(user => tags.Contains(user.DisplayName.ToLower()));
    }
