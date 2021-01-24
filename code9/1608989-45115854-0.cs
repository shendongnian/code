    var project = XDocument.Load(pathToTheProjectFile);
    var ns = project.Root.GetDefaultNamespace();
    var properties = project.Descendants(ns + "PropertyGroup")
                            .SelectMany(property => property.Elements())
                            .ToDictionary(element => $"$({element.Name.LocalName})",
                                          element => element.Value);
    var hintPath = project.Descendants(ns + "HintPath")
                          .Select(path => ReplaceWithProperty(path.Value, properties));
    private string ReplaceWithProperty(string path, Dictionary<string, string> properties)
    {
        var currentPath = path;
        foreach(var pair in properties)
        {
            currentPath = currentPath.Replace(pair.Key, pair.Value);
        }
        return currentPath;
    }
