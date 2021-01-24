    public static String SearchFile(string path)
    {
        var document = XDocument.Parse(File.ReadAllText(path));
        foreach (var thisRegistration in document.Element("stuff").Elements("Registration"))
        {
            var typeValue = thisRegistration.Element("TYPE").Value;
            if (typeValue == "2" ||
                typeValue == "3")
            {
                return "True";
            }
        }
        return "False";
    }
