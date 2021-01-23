    public static class SettingsConverter
    {
        public static string FromXmlToJson(string xml)
        {
            Settings settings = null;
            // read your xml file and assign values to the settings object
            // now you can "serialize" settings object into Json
            return JsonSerialization.Serialize(settings);
        }
    
        public static string FromJsonToXml(string json)
        {
            Settings settings = JsonSerialization.Deserialize<MeSettings>(json);
            // save settings using your "xml" serialization
            return xmlString; // return xml string
        }
    }
