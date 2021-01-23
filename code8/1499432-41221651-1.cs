    public static void Navigate(this IRegionManager regionManager, Type type)
    {
        regionManager.RequestNavigate("MainRegion",
            new Uri(type.Name, UriKind.Relative),
            result =>
            {
            });
    }
