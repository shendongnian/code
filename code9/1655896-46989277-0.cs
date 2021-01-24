    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
    randoms = string.IsNullOrEmpty(ConfigurationManager.AppSettings["randoms"]) ? new List<int>() : ConfigurationManager.AppSettings["randoms"].Split(',').Select(int.Parse).ToList();
    Random rnd = new Random();
    int random = rnd.Next(1, 10000);
    if (!randoms.Contains(random))
    {
        randoms.Add(random);
        config.AppSettings.Settings.Add("randoms", string.Join(",", randoms.Select(p => p.ToString()).ToList()));
        config.Save(ConfigurationSaveMode.Minimal);
    }
