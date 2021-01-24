    var project = XDocument.Load(pathToTheProjectFile);
    var ns = project.Root.GetDefaultNamespace();
    var properties = project.Descendants(ns + "PropertyGroup")
                            .SelectMany(property => property.Elements())
                            .ToDictionary(element => $"$({element.Name.LocalName})",
                                          element => element.Value);
    var hintPath = project.Descendants(ns + "HintPath")
                          .Select(element => 
                          {
                               return properties.Aggregate(
                                   element.Value, 
                                   (path, pair) => path.Replace(pair.Key, pair.Value))
                                   );
                          });
    
