    ModelInfo mi = new ModelInfo { ModelName = "Andrea", ModelAge = 23 };
    var xmlRoot = mi.GetType().GetCustomAttribute<XmlRootAttribute>();
    if (xmlRoot != null)
    {
        Console.WriteLine(xmlRoot.ElementName);
        Console.WriteLine(xmlRoot.Namespace);
    }
