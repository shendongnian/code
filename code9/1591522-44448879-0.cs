    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        List<string> elem = new List<string>();
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(xml);
        foreach (XmlAttribute folderName in xmldoc.SelectNodes("//folder/@name[starts-with(., '"+ startingLetter +"')]"))
        {
            elem.Add(folderName.Value);
            Console.WriteLine(folderName.Value);
        }
        return elem;
    }
