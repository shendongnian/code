    var manager = new FirefoxProfileManager();
    var profiles = (Dictionary<string, string>)manager.GetType()
        .GetField("profiles", BindingFlags.Instance | BindingFlags.NonPublic)
        .GetValue(manager);
    string directory;
    if (profiles.TryGetValue("Selenium", out directory))
        options.Profile = directory;
