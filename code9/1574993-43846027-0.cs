    public string GetResource()
    {
        var assembly = typeof(TestClass.Class1).GetTypeInfo().Assembly;
        // This shows the available items.
        string[] resources = assembly.GetManifestResourceNames();
        var stream = assembly.GetManifestResourceStream("TestClass.test.txt");
            
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
