    var tests = xInformations.Descendants("test")
                             .Select(x => 
                             {
                                 new 
                                 {
                                     Id = x.Attribute("id").Value,
                                     Name = x.Element("name").Value,
                                     Age = x.Element("age").Value,
                                     Info = x.Element("informations").Value
                                 }
                             });
    foreach(var test in tests)
    {
        // test.Id
        // test.Name
        // test.Age
        // test.Info       
    }
