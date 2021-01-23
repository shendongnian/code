    private void method()
    {
        var assembly = Assembly.Load("taglib");
        var type = assembly.GetType("namespace.File"); // namespace qualified class name
        // assuming you only have one Create method, otherwise use reflection to resolve overloads
        var method = type.GetMethod("Create");
        dynamic file = method.Invoke(null, new[] { "C:\\temp\\some.mp3" }); // null for static methods
        var tag = file.GetTag(TagLib.TagTypes.Id3v2); // not sure if you can pass those params, 
                                                      // may be do reflection to get them too
    }
