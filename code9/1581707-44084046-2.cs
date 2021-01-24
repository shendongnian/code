    // using System.Globalization;
    protected void Application_Start()
    {
        // Formatting numbers, dates, etc.
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
        // UI strings that we have localized.
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");
    }
