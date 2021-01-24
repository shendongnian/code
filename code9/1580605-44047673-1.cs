    var doc = XDocument.Load(yourXmlFilePath);
    
    var packages = doc.Descendants("package")
                    .Select(p => new
                    {
                        Name = p.Elements("property")
                                .SingleOrDefault(i => i.Attribute("name")?.Value == "cic.name")
                                ?.Attribute("value")
                                ?.Value,
                        Version = p.Elements("property")
                                   .SingleOrDefault(i => i.Attribute("name")?.Value == "cic.version")
                                   ?.Attribute("value")
                                   ?.Value
                    }).ToList();
    
    var result = names.Select(i => string.Format("{0} {1}", i.Name, i.Version)).ToList();
    //result: "IBM Studio 13.4"
    //        "Windows XP 10.3.2"
    
