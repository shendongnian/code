    var root = new { Name = "John", Age = 18 };
    var sb = new StringBuilder();
    using (var sw = new StringWriter(sb))
    using (var writer = new SplunkLogTextWriter(sw))
    {
        JsonSerializer.CreateDefault().Serialize(writer, root);
    }
    Console.WriteLine(sb);
