    Configs cfg = new Configs();
    cfg.Speech = 0;
    cfg.KeepActive = 1;
    using (StreamWriter file = File.CreateText("myTestFile.txt"))
    {
        
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, cfg);
    }
