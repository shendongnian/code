    static void Main(string[] args)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        ConfigurationSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
        if (!section.SectionInformation.IsProtected)
        {
            Console.WriteLine("Protecting connection strings...");
            section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
        }
        else
        {
            Console.WriteLine("Unprotecting connection strings...");
            section.SectionInformation.UnprotectSection();
        }
        section.SectionInformation.ForceSave = true;
        config.Save(ConfigurationSaveMode.Full);
        var cs = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnKey"];
        Console.WriteLine(cs.ConnectionString);
        Console.ReadLine();
    }
