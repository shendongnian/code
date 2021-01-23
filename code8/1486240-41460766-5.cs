    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(
            new AuthorizeAttributeWithAnonTimeoutAttribute
            {
                // By example, 10 minutes
                AnonymousMinutesTimeout = 10
            });
        // Your other filters
        ...
    }
