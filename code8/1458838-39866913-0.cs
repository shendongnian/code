    IEnumerable<IPublishedContent> GetFirstTenFiltered(IEnumerable<IPublishedContent> posts)
    {
        foreach (var n in posts.Take(10))
        {
                if (condition=true)
                {
                    yield return n;
                }
        }
    }
