    string name = "Brian";
    XDocument doc = XDocument.Load(yourXmlFile);
    var matches = doc.Root
                     .Descendants("Option")
                     .Where(option => name.StartsWith(option.Element("NameStartsWith").Value))
                     .Select(option => option.Element("Data").Value);
    foreach(var data in matches)
    {
        Console.WriteLine("The Answer is: {data}");
    }
