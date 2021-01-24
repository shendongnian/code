    var assembly = Assembly.GetExecutingAssembly();
    using (var stream = assembly.GetManifestResourceStream(resourceName))
    using (var reader = new StreamReader(stream))
    {
        string text = reader.ReadToEnd();
        File.WriteAllText(fileName, text);
    }
