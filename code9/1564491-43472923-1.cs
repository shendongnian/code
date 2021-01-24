    // Create a default config
    var defaultEnvCfg = new EnvironmentConfig
    {
        Title = "USWE Environment",
        XmlPath = @"\\server\share\xmlfiles",
        SharepointPath = @"\\server\sites\enterpriseportal\documents",
        SubFolders = new List<SubFolder>
        {
            new SubFolder { Folder = "Folder1", IsStandard = true },
            new SubFolder { Folder = "Folder2", IsStandard = false }
        }
    };
    // Display original values:
    Console.WriteLine(defaultEnvCfg.ToString());
    // Serialize the config to a file
    var pathToEnvCfg = @"c:\public\temp\Environment.config";
    var serializer = new XmlSerializer(defaultEnvCfg.GetType());
            
    using (var writer = new XmlTextWriter(
        pathToEnvCfg, Encoding.UTF8) { Formatting = Formatting.Indented })
    {
        serializer.Serialize(writer, defaultEnvCfg);
    }
    // Prompt user to change the file
    Console.Write($"Please modify the file then press [Enter] when done: {pathToEnvCfg}");
    Console.ReadLine();
    // Deserialize the modified file and update our object with the new settings
    using (var reader = XmlReader.Create(pathToEnvCfg))
    {
        defaultEnvCfg = (EnvironmentConfig)serializer.Deserialize(reader);
    }
    // Display new values:
    Console.WriteLine(defaultEnvCfg.ToString());
    Console.Write("\nDone!\nPress any key to exit...");
    Console.ReadKey();
