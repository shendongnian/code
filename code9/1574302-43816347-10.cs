    public static void Save(AppSettings settings)
    {
        string xmlText = string.Empty;
        var xs = new XmlSerializer(settings.GetType());
        using (var xml = new StringWriter())
        {
            xs.Serialize(xml, obj);
            xml.Flush();
            xmlText = xml.ToString();
        }
        string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        File.WriteAllText(roamingPath + @"\settings.xml", xmlText);
    }
    public static AppSettings Load()
    {
        string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        if (!File.Exists(roamingPath + @"\settings.xml"))
            return new AppSettings();
        string xmlText = File.ReadAllText(roamingPath + @"\settings.xml");
        var xs = new XmlSerializer(typeof(AppSettings));
        return (AppSettings)xs.Deserialize(new StringReader(xmlText));
    }
