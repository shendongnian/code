    public CustomSettings GetInitPath()
    {
        var serializer = new XmlSerializer(typeof(CustomSettings));
        using (var myFstream = new FileStream(@"U:\Alex\prefs.xml", FileMode.Open))
        {
            return (CustomSettings) serializer.Deserialize(myFstream);
        }
    }
