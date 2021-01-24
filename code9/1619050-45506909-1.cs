    public static void RegisterGlobalFilters(
        GlobalFilterCollection filters, Container container)
    {
        // Call extension method
        filters.AddFilter<AuthoriseActionFilter>(container);
        filters.Add(new HandleErrorAttribute());
    }
