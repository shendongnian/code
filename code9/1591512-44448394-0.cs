    public static string SerializeToJSON<T>(T obj) {
        return new JavaScriptSerializer().Serialize(obj);
    }
    public static T DeserializeJSON<T>(string json) {
        return new JavaScriptSerializer().Deserialize<T>(json);
    }
    // Fake path for the example
    string path = "~/myFile.json";
    // Instanciates a fake dictionary for the example.
    Dictionary<string,string> myDict = new Dictionary<string,string>() { new KeyValuePair("A","1") };
    
    // Using serialisation, we save the content of our dictionary into a text file.
    string json = SerializeToJSON<Dictionary<string,string>>(myDict);
    File.WriteAllText(path, json);
    // Then with deserialisation, we get back our old dictionary. 
    Dictionary myOtherDict = Dictionary<string,string>DeserializeJSON<Dictionary<string,string>>(File.ReadAllText(path));
