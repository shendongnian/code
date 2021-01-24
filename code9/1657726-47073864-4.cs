    private static void SaveToXml(object data, string filename) {
        XmlSerializer xs = new XmlSerializer(data.GetType());
        using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
            xs.Serialize(fs, data);
        }
    }
