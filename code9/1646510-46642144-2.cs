    public static PageConventionCollection ReplacePageRoute(this PageConventionCollection conventions, string pageName, string route)
    {
        if (conventions == null)
            throw new ArgumentNullException(nameof(conventions));
        if (string.IsNullOrEmpty(pageName))
            throw new ArgumentNullException(nameof(pageName));
        if (route == null)
            throw new ArgumentNullException(nameof(route));
        conventions.AddPageRouteModelConvention(pageName, model =>
        {
            // clear all existing selectors
            model.Selectors.Clear();
            // add a single selector for the new route
            model.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel
                {
                    Template = route,
                }
            });
        });
        return conventions;
    }
