    var doc = XDocument.Load(pathToTheProjectFile);
    var ns = doc.Root.GetDefaultNamespace();
    var properties = doc.Descendants(ns + "PropertyGroup")
                        .SelectMany(property => property.Elements())
                        .Select(element => new 
                        { 
                            Old = $"$({element.Name.LocalName})", 
                            New = element.Value 
                        });
    var hintPathCollection = 
        doc.Descendants(ns + "HintPath")
           .Select(element => properties.Aggregate(element.Value, 
                                                   (path, values) => path.Replace(values.Old, values.New)));
    
