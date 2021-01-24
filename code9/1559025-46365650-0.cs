These lines should go last, **after** all MapRoute calls:
    var settings = new FriendlyUrlSettings();
    settings.AutoRedirectMode = RedirectMode.Permanent;
    routes.EnableFriendlyUrls(settings);
If you run them before, then Page.RouteData.Values will be empty.
