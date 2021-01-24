    public static void RegisterBundles(BundleCollection bundles)
    {
        //perhaps something like.
        foreach (MyTheme theme in ThemeController.SelectAll())
	       AddThemeStyleBundle(bundles, theme.BundleName, theme.ThemeName);
    }
    private static void AddThemeStyleBundle(BundleCollection bundles,string bundleName, string themeName)
        bundles.Add(new StyleImagePathBundle(bundlename).Include(
            "~/Content/bootstrap.css", 
            String.Format("~/Content/{0}/Institution.css",themeName), 
            "~/Content/site.css"));
    }
