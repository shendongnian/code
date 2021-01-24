    public static T open<T>(string path) where T : class {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fileStream = new FileStream(path, FileMode.Open)) {
            return (T)xmlSerializer.Deserialize(fileStream);
        }
    }
