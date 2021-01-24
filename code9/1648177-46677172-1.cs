    public static void addColor2(string newColor)
    {
        var document = XDocument.Load("C:\\Users\\tobiajj1\\Desktop\\XML_C#\\testDetailManager\\original.xml");
        if(!document.Root.Elements("color").Any(element => element.Value == newColor))
        {
            document.Root.Add(new XElement("color", newColor));
            document.Save("C:\\Users\\tobiajj1\\Desktop\\XML_C#\\testDetailManager\\original.xml");
        }
    }
