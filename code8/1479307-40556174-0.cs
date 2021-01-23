    private void TestForm_Load(object sender, EventArgs e)
    {
        string directory = Path.Combine(Environment.SpecialFolder.ApplicationData, "TestFolder");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        string file = Path.Combine(directory, "settings.xml");
        if (!File.Exists(file))
            File.Create(file);
    }
